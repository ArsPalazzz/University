const { send } = require("m06_pav2");
require("dotenv").config();

async function main() {
  let from = "palaznika608@gmail.com";
  let pass = "tirbsrdxhqyaxdpy";
  let message = "THE LAST TASK";

  try {
    await send(from, pass, message);
    console.log("Success");
  } catch (error) {
    console.error("Error:", error);
  }
}

main();
