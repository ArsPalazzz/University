const dgram = require("dgram");
const fs = require("fs");
const config = require("./../config");

const timeServiceHandlers = {
  time: getTimeHandler,
  ready: checkServerReady,
  "ready-ok": coordinatorIsReady,
  "init-coordinator": initCoordinator,
  "re-init-coordinator": reInitCoordinator,
};
const coordinatorFilePath = "./../coordinator.json";
const timeServerConfig = config.timeService[`192.168.185.55`];
const self = (module.exports = {
  initTimeServer: (count) => {
    const server = dgram.createSocket("udp4");
    server.ready = false;

    // const timeServerConfig = config.timeService[`127.0.0.${count + 1}`];

    // let timeServerConfig;

    // if (count == 1) timeServerConfig = config.timeService["192.168.185.55"];
    // else if (count == 2)
    //   timeServerConfig = config.timeService["192.168.185.158"];
    // else if (count == 3)
    //   timeServerConfig = config.timeService["192.168.185.155"];

    server.on("message", (message, client) => {
      console.log(
        `Server-${count} got: "${message}" from ${client.address}:${
          client.port
        } with rank ${config.timeService[client.address].rang}`
      );
      const handler = timeServiceHandlers[message];
      if (handler) {
        handler(server, client);
      }
    });

    server.on("error", (err) => {
      console.log(`Server-${count} error:\n${err.stack}`);
      server.close();
    });

    server.on("listening", () => {
      server.setBroadcast(true);
      const address = server.address();
      console.log(
        `Server-${count} is listening to ${address.address}:${address.port}`
      );

      server.ready = true;
      self.setCoordinator(address.address, address.port);
      setTimeout(() => {
        server.send(
          "init-coordinator",
          config.timeService.port,
          config.timeService.broadcastHost
        );
      }, 1000);
    });

    server.bind(config.timeService.port, timeServerConfig.host);

    setInterval(
      self.checkCoordinatorAvailable,
      config.timeService.checkCoordinatorInterval,
      server
    );

    return server;
  },

  getCoordinator: () => {
    return JSON.parse(fs.readFileSync(coordinatorFilePath).toString());
  },

  setCoordinator: (host, port) => {
    fs.writeFile(
      coordinatorFilePath,
      JSON.stringify({ {'111.111.111.111'}, port }, null, "  "),
      (err) => {
        if (err) {
          console.log(`Error while saving current coordinator`);
        }
      }
    );
  },

  checkCoordinatorAvailable: (server) => {
    server.coordinatorReady = false;
    server.coordinator = {
      host: self.getCoordinator().host,
      port: self.getCoordinator().port,
    };
    console.log("Check coordinator is available");
    if (timeServerConfig.host !== server.coordinator.host) {
      server.send("ready", server.coordinator.port, server.coordinator.host);
      self.recheckCoordinatorAvailable(server, 1);
    }
  },

  recheckCoordinatorAvailable: (server, attempt) => {
    setTimeout(() => {
      if (
        !server.coordinatorReady &&
        attempt < config.timeService.checkCoordinatorAttempts
      ) {
        console.log("Recheck coordinator is available");
        server.send("ready", server.coordinator.port, server.coordinator.host);
        self.recheckCoordinatorAvailable(server, ++attempt);
      } else if (server.coordinatorReady) {
        console.log("Coordinator is available");
      } else {
        console.log("Coordinator is not available");
        server.send(
          "re-init-coordinator",
          config.timeService.port,
          config.timeService.broadcastHost
        );
      }
    }, 1000);
  },
  //   recheckCoordinatorAvailable: (server, attempt) => {
  //     setTimeout(() => {
  //       if (
  //         !server.coordinatorReady &&
  //         attempt < config.timeService.checkCoordinatorAttempts
  //       ) {
  //         console.log("Recheck coordinator is available");

  //         // Получаем ранг текущего сервера
  //         const myRank = config.timeService[server.address().address].rang;

  //         // Отправляем запрос на голосование только тем серверам, у которых ранг выше ранга текущего сервера
  //         for (const [address, serverConfig] of Object.entries(
  //           config.timeService
  //         )) {
  //           if (serverConfig.rang > myRank) {
  //             server.send(
  //               "ready",
  //               server.coordinator.port,
  //               server.coordinator.host
  //             );
  //           }
  //         }

  //         self.recheckCoordinatorAvailable(server, ++attempt);
  //       } else if (server.coordinatorReady) {
  //         console.log("Coordinator is available");
  //       } else {
  //         console.log("Coordinator is not available");
  //         server.send(
  //           "re-init-coordinator",
  //           config.timeService.port,
  //           config.timeService.broadcastHost
  //         );
  //       }
  //     }, 300);
  //   },
});

function getTimeHandler(server, client) {
  if (server.ready) {
    server.send(new Date().toISOString(), client.port, client.address);
  }
}

function checkServerReady(server, client) {
  if (server.ready) {
    server.send("ready-ok", client.port, client.address);
  }
}

function coordinatorIsReady(server, client) {
  server.coordinatorReady = true;
}

function initCoordinator(server, client) {
  server.ready = true;
  server.coordinatorReady = true;
  server.coordinator = {
    host: client.address,
    port: client.port,
  };
  console.log(
    `Initial coordinator: ${server.coordinator.host}:${server.coordinator.port}`
  );
}

function reInitCoordinator(server, client) {
  if (!server.coordinatorReady) {
    console.log("New coordinator suggestion");

    const serverRank = config.timeService[server.address().address].rang;
    const myRank = config.timeService[client.address].rang;

    if (myRank > serverRank) {
      console.log("Higher address suggested");
      server.coordinatorReady = true;
      self.setCoordinator(client.address, client.port);

      const message = JSON.stringify({
        host: client.address,
        port: client.port,
      });
      // server.send(message, config.timeService.port, client.address);
      // return;

      for (const [address, serverConfig] of Object.entries(
        config.timeService
      )) {
        if (serverConfig.rang > myRank) {
          server.send(message, config.timeService.port, address);
        }
      }

      return;
    }

    console.log("Lower or equal address suggested, ignoring");
  }
}
