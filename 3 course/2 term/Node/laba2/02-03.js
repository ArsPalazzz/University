const http = require("http");

const PORT = 5000;

const server = http.createServer((req, res) => {
  if (req.url === "/api/name" && req.method === "GET") {
    const fullName = "Палазник Арсений Викторович";

    res.writeHead(200, { "Content-Type": "text/plain; charset=utf-8" });
    res.end(fullName);
  } else {
    res.writeHead(404, { "Content-Type": "text/plain" });
    res.end("Not Found");
  }
});

server.listen(PORT, () => {
  console.log(`Server running at http://localhost:${PORT}/`);
});
