const express = require("express");
const session = require("express-session");
const passport = require("passport");
const LocalStrategy = require("passport-local").Strategy;
const flash = require("connect-flash");
const bodyParser = require("body-parser");

const app = express();
const port = 5000;

const allowedUsers = require("./allowedUsers.json");

app.use(
  session({
    secret: "secret",
    resave: false,
    saveUninitialized: true,
  })
);

app.use(passport.initialize());
app.use(passport.session());
app.use(flash());

app.use(bodyParser.urlencoded({ extended: false }));

passport.use(
  new LocalStrategy((username, password, done) => {
    const user = allowedUsers.find(
      (user) => user.username === username && user.password === password
    );
    if (user) {
      return done(null, user);
    } else {
      return done(null, false, { message: "Incorrect username or password" });
    }
  })
);

passport.serializeUser((user, done) => {
  done(null, user.id);
});

passport.deserializeUser((id, done) => {
  const user = allowedUsers.find((user) => user.id === id);
  done(null, user);
});

app.get("/login", (req, res) => {
  res.send(`
  <html>
    <head>
      <title>Login</title>
      <style>
        /* Ваши стили CSS */
        body {
          font-family: Arial, sans-serif;
          background-color: #f4f4f4;
          margin: 0;
          padding: 0;
        }
        form {
          background-color: #ffffff;
          width: 300px;
          margin: 100px auto;
          padding: 20px;
          border-radius: 5px;
          box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        label {
          display: block;
          margin-bottom: 5px;
        }
        input[type="text"],
        input[type="password"] {
          width: 100%;
          padding: 10px;
          margin-bottom: 10px;
          border: 1px solid #ccc;
          border-radius: 3px;
        }
        input[type="submit"] {
          width: 100%;
          padding: 10px;
          background-color: #007bff;
          border: none;
          border-radius: 3px;
          color: #ffffff;
          cursor: pointer;
        }
        input[type="submit"]:hover {
          background-color: #0056b3;
        }
      </style>
    </head>
    <body>
    <form action="/login" method="post">
        <div>
            <label>Username:</label>
            <input type="text" name="username">
        </div>
        <div>
            <label>Password:</label>
            <input type="password" name="password">
        </div>
        <div>
            <input type="submit" value="Log In">
        </div>
    </form>
    </body>
    </html>
    `);
});

app.post(
  "/login",
  passport.authenticate("local", {
    successRedirect: "/profile",
    failureRedirect: "/login",
    failureFlash: true,
  })
);

app.get("/logout", (req, res) => {
  req.logout((err) => {
    if (err) {
      return next(err);
    }
    res.redirect("/");
  });
});

app.get("/profile", (req, res) => {
  if (req.isAuthenticated()) {
    res.send("Authenticated User: " + JSON.stringify(req.user));
  } else {
    res.redirect("/login");
  }
});

app.all("*", (req, res) => {
  res.status(404).send("404 Not Found");
});

const main = () => {
  try {
    app.listen(port, () => {
      console.log(`Server is listening at http://localhost:${port}`);
    });
  } catch (e) {
    console.log(e);
  }
};

main();
