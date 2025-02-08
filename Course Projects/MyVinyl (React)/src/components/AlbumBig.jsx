import React, { useState } from "react";
import { Carousel } from "react-responsive-carousel";
import "react-responsive-carousel/lib/styles/carousel.min.css"; // requires a loader
import classes from "./../sassModules/AlbumBig.module.scss";
import "./../sassModules/None.css";
import AlbumSmallAdd from "./AlbumSmallAdd";
import { useLayoutEffect } from "react";
import InfForPages from "./InfForPages";

function AlbumBig(props) {
  let aSideSongs = [];
  let bSideSongs = [];
  let genres = [props.allObj.genres.genre1],
    firstEl = true;

  for (let key in props.allObj.sides[0]) {
    aSideSongs.push(
      <p>
        {key.toUpperCase()}. {props.allObj.sides[0][key]}
      </p>
    );
  }

  for (let key in props.allObj.sides[1]) {
    bSideSongs.push(
      <p>
        {key.toUpperCase()}. {props.allObj.sides[1][key]}
      </p>
    );
  }

  for (let key in props.allObj.genres) {
    if (firstEl) {
      firstEl = false;
      continue;
    }
    genres.push(", ".concat(props.allObj.genres[key]));
  }

  useLayoutEffect(() => {
    window.scrollTo(0, 0);
  });

  return (
    <div className={classes.container}>
      <img src={props.allObj.back} className={classes.backgr} />
      <div className={classes.coversAndInf}>
        <div className={classes.covers}>
          <Carousel className={classes.carous}>
            <div className={classes.image}>
              <img src={props.allObj.image} />
            </div>
            <div className={classes.image}>
              <img src={props.allObj.image2} />
            </div>
            <div className={classes.image}>
              <img src={props.allObj.image3} />
            </div>
            <div className={classes.image}>
              <img src={props.allObj.image4} />
            </div>
          </Carousel>
        </div>
        <div className={classes.inf}>
          <div className={classes.almostAll}>
            <h3 className={classes.name}>{props.allObj.name} [LP]</h3>
            <p className={classes.article}>Article: {props.allObj.article}</p>
            <p className={classes.price}>{props.allObj.price}</p>
            <button
              className={classes.btn}
              onClick={() => props.onAdd(props.allObj)}
            >
              Add to bag
            </button>
            <div className={classes.sides}>
              <div className={classes.sideA}>
                <h3>Side A</h3>

                {aSideSongs}
              </div>
              <div className={classes.sideB}>
                <h3>Side B</h3>
                {bSideSongs}
              </div>
            </div>
          </div>
          <div className={classes.genreAndYear}>
            <p>
              Genres: {genres}
              {/* Genre: {props.allObj.genre1}, {props.allObj.genre2},{" "}
              {props.allObj.genre3} */}
            </p>
            <p>Year of publication: {props.allObj.year}</p>
          </div>
        </div>
      </div>
      <div className={classes.description}>
        <h4>Description</h4>
        <p>{props.allObj.description}</p>
      </div>
      <div className={classes.related}>
        <h2>Related Products</h2>
        <AlbumSmallAdd
          genre1={props.allObj.genres.genre1}
          genre2={props.allObj.genres.genre2}
          genre3={props.allObj.genres.genre3}
          name={props.allObj.name}
        />
      </div>
    </div>
  );
}

export default AlbumBig;
