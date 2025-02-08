const { send } = require("./m06_PAV2/m06_PAV2");
require("dotenv").config();

const mailAddr = process.env.SMTP_EMAIL;
const mailPass = process.env.SMTP_PASSWORD;

send(mailAddr, mailPass, "HIHIHIHA")
  .then((response) => {
    console.log("Email sent:", response);
  })
  .catch((error) => {
    console.error("Error occurred while sending email:", error);
  });
