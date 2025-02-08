const http = require("http");
const fs = require("fs");
const nodemailer = require("nodemailer");
require("dotenv").config();

const PORT = 5000;

const server = http.createServer((req, res) => {
  if (req.url === "/") {
    fs.readFile("index.html", (err, data) => {
      if (err) {
        res.writeHead(500);
        res.end("Internal Server Error");
      } else {
        res.writeHead(200, { "Content-Type": "text/html" });
        res.end(data);
      }
    });
  } else if (req.url === "/send-mail" && req.method === "POST") {
    let body = "";
    req.on("data", (chunk) => {
      body += chunk.toString();
    });
    req.on("end", () => {
      const { sender, recipient, message } = JSON.parse(body);
      console.log(process.env.SMTP_PASSWORD);

      const transporter = nodemailer.createTransport({
        service: "gmail",
        auth: {
          user: sender,
          pass: process.env.SMTP_PASSWORD,
        },
      });

      const mailOptions = {
        from: sender,
        to: recipient,
        subject: "Message from Node.js Application",
        text: message,
      };

      transporter.sendMail(mailOptions, (err, info) => {
        if (err) {
          console.log(err);
          res.writeHead(500);
          res.end("Error occurred while sending email");
        } else {
          console.log("Email sent:", info.response);
          res.writeHead(200);
          res.end("Email sent successfully");
        }
      });
    });
  } else {
    res.writeHead(404);
    res.end("Not Found");
  }
});

server.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
