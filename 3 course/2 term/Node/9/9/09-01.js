const express = require("express");
const passport = require("passport");
const session = require("express-session");
const FacebookStrategy = require("passport-facebook").Strategy;
const env = require("dotenv");

env.config();

const app = express();
const port = 5000;

app.use(
  session({
    secret: "secret",
    resave: false,
    saveUninitialized: true,
  })
);

app.use(passport.initialize());
app.use(passport.session());

passport.use(
  new FacebookStrategy(
    {
      clientID: process.env.FACEBOOK_APP_ID,
      clientSecret: process.env.FACEBOOK_APP_SECRET,
      callbackURL: process.env.REDIRECT_URI,
      profileFields: ["id", "displayName", "name", "picture.type(large)"],
    },
    (accessToken, refreshToken, profile, cb) => {
      return cb(null, {
        id: profile.id,
        displayName: profile.displayName,
        picture: profile.photos
          ? profile.photos[0].value
          : "/img/faces/unknown-user-pic.jpg",
      });
    }
  )
);

passport.serializeUser((user, done) => {
  done(null, user);
});

passport.deserializeUser((user, done) => {
  done(null, user);
});

app.get("/login", (req, res) => {
  res.send(` <div style="text-align: center; margin-top: 100px;">
  <h1 style="font-size: 24px; margin-bottom: 20px;">Login with Facebook</h1>
  <a style="display: inline-block; padding: 10px 20px; background-color: #4267B2; color: #fff; text-decoration: none; border-radius: 5px;" href="/auth/facebook">Login</a>
</div>`);
});

app.get("/auth/facebook", passport.authenticate("facebook"));

app.get(
  "/auth/facebook/callback",
  passport.authenticate("facebook", { failureRedirect: "/login" }),
  (req, res) => {
    res.redirect("/resource");
  }
);

app.get("/resource", (req, res) => {
  if (req.isAuthenticated()) {
    const user = req.user;
    res.send(
      ` <div style="text-align: center; margin-top: 100px;">
      <img src='${user.picture}' style="width: 200px; height: 200px"/>
      <h1 style="font-size: 24px; margin-bottom: 20px;">Welcome, ${user.displayName}</h1>
      <p>Authenticated User ID: ${user.id}</p>
      <a style="display: inline-block; padding: 10px 20px; background-color: #4267B2; color: #fff; text-decoration: none; border-radius: 5px; margin-top: 20px;" href="/logout">Logout</a>
    </div>`
    );
  } else {
    res.redirect("/login");
  }
});

app.get("/logout", (req, res) => {
  req.logout(() => {
    res.redirect("/");
  });
});

app.all("*", (req, res) => {
  res.status(404).send("404 Not Found");
});

const main = () => {
  try {
    app.listen(port, () => {
      console.log(`Server is listening at http://localhost:${port}`);
    });
  } catch (err) {
    console.error(err);
  }
};

main();
