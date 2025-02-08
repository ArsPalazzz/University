import React from "react";
import classes from "./../sassModules/AlbumSmallAdd.module.scss";
import InfForPages from "./InfForPages";
import { Link } from "react-router-dom";
import { useState } from "react";

const AlbumSmallAdd = (props) => {
  const [countOfAlb, setCountOfAlb] = useState(0);

  let count1 = 0;

  let arr = [];
  //((item.genres.genre1 === props.genre1) && (item.genres.genre2 === props.genre2)) || ((item.genres.genre1 === props.genre1) && (item.genres.genre2 === props.genre3)) ||  ((item.genres.genre1 === props.genre1) && (item.genres.genre3 === props.genre3)) || ((item.genres.genre1 === props.genre1) && (item.genres.genre3 === props.genre2)) || ((item.genres.genre2 === props.genre2) && (item.genres.genre3 === props.genre3)) || ((item.genres.genre2 === props.genre2) && (item.genres.genre3 === props.genre1)) || ((item.genres.genre2 === props.genre2) && (item.genres.genre1 === props.genre3)) || ((item.genres.genre1 === props.genre2) && (item.genres.genre3 === props.genre3)) || ((item.genres.genre2 === props.genre1) && (item.genres.genre3 === props.genre3)) || ((item.genres.genre2 === props.genre1) && (item.genres.genre3 === props.genre2)) || ((item.genres.genre1 === props.genre2) && (item.genres.genre2 === props.genre1)) || ((item.genres.genre1 === props.genre3) && (item.genres.genre2 === props.genre1)) || ((item.genres.genre1 === props.genre2) && (item.genres.genre3 === props.genre1)) || ((item.genres.genre1 === props.genre2) && (item.genres.genre2 === props.genre3)) || ((item.genres.genre1 === props.genre3) && (item.genres.genre3 === props.genre2)) ||
  //(item.genres.genre1 === props.genre1) || (item.genres.genre1 === props.genre2) || (item.genres.genre1 === props.genre3) || (item.genres.genre2 === props.genre1) || (item.genres.genre2 === props.genre2) || (item.genres.genre2 === props.genre3) || (item.genres.genre3 === props.genre1) || (item.genres.genre3 === props.genre2) || (item.genres.genre3 === props.genre3)
  return (
    <div className={classes.container}>
      {InfForPages.map((item) =>
        count1 < 4 //Если количество не больше 4 - продолжаем искать
          ? (item.genres.genre1 === props.genre1 &&
              item.genres.genre2 === props.genre2 &&
              item.genres.genre3 === props.genre3) ||
            (item.genres.genre1 === props.genre1 &&
              item.genres.genre2 === props.genre3 &&
              item.genres.genre3 === props.genre2) ||
            (item.genres.genre1 === props.genre2 &&
              item.genres.genre2 === props.genre3 &&
              item.genres.genre3 === props.genre1) ||
            (item.genres.genre1 === props.genre2 &&
              item.genres.genre2 === props.genre1 &&
              item.genres.genre3 === props.genre3) ||
            (item.genres.genre1 === props.genre3 &&
              item.genres.genre2 === props.genre2 &&
              item.genres.genre3 === props.genre1) ||
            (item.genres.genre1 === props.genre3 &&
              item.genres.genre2 === props.genre1 &&
              item.genres.genre3 === props.genre2)
            ? item.name !== props.name && arr.indexOf(item.name) === -1
              ? arr.push(item.name) && (
                  <Link to={item.path} className={classes.link}>
                    <div className={classes.block} key={item.id}>
                      <img src={item.image} />
                      <p className={classes.genres}>
                        {item.genres.genre1}, {item.genres.genre2},{" "}
                        {item.genres.genre3}
                      </p>
                      <h5>{item.name}</h5>
                      <p className={classes.price}>{item.price}</p>
                      {/* {() => setCountOfAlb(countOfAlb + 1)} */}
                      {/* {setCountOfAlb((current) => current+1)}
                            {console.log(countOfAlb)} */}
                      <div className={classes.count}>{count1++}</div>
                    </div>
                  </Link>
                )
              : null
            : null
          : null
      )}
      {InfForPages.map((item) =>
        count1 < 4 //Если количество не больше 4 - продолжаем искать
          ? (item.genres.genre1 === props.genre1 &&
              item.genres.genre2 === props.genre2) ||
            (item.genres.genre1 === props.genre1 &&
              item.genres.genre2 === props.genre3) ||
            (item.genres.genre1 === props.genre1 &&
              item.genres.genre3 === props.genre3) ||
            (item.genres.genre1 === props.genre1 &&
              item.genres.genre3 === props.genre2) ||
            (item.genres.genre2 === props.genre2 &&
              item.genres.genre3 === props.genre3) ||
            (item.genres.genre2 === props.genre2 &&
              item.genres.genre3 === props.genre1) ||
            (item.genres.genre2 === props.genre2 &&
              item.genres.genre1 === props.genre3) ||
            (item.genres.genre1 === props.genre2 &&
              item.genres.genre3 === props.genre3) ||
            (item.genres.genre2 === props.genre1 &&
              item.genres.genre3 === props.genre3) ||
            (item.genres.genre2 === props.genre1 &&
              item.genres.genre3 === props.genre2) ||
            (item.genres.genre1 === props.genre2 &&
              item.genres.genre2 === props.genre1) ||
            (item.genres.genre1 === props.genre3 &&
              item.genres.genre2 === props.genre1) ||
            (item.genres.genre1 === props.genre2 &&
              item.genres.genre3 === props.genre1) ||
            (item.genres.genre1 === props.genre2 &&
              item.genres.genre2 === props.genre3) ||
            (item.genres.genre1 === props.genre3 &&
              item.genres.genre3 === props.genre2)
            ? item.name !== props.name && arr.indexOf(item.name) === -1
              ? arr.push(item.name) && (
                  <Link to={item.path} className={classes.link}>
                    <div className={classes.block} key={item.id}>
                      <img src={item.image} />
                      <p className={classes.genres}>
                        {item.genres.genre1}, {item.genres.genre2},{" "}
                        {item.genres.genre3}
                      </p>
                      <h5>{item.name}</h5>
                      <p className={classes.price}>{item.price}</p>
                      {/* {() => setCountOfAlb(countOfAlb + 1)} */}
                      {/* {setCountOfAlb((current) => current+1)}
                            {console.log(countOfAlb)} */}
                      <div className={classes.count}>{count1++}</div>
                    </div>
                  </Link>
                )
              : null
            : null
          : null
      )}
      {InfForPages.map((item) =>
        count1 < 4 //Если количество не больше 4 - продолжаем искать
          ? item.genres.genre1 === props.genre1 ||
            item.genres.genre1 === props.genre2 ||
            item.genres.genre1 === props.genre3 ||
            item.genres.genre2 === props.genre1 ||
            item.genres.genre2 === props.genre2 ||
            item.genres.genre2 === props.genre3 ||
            item.genres.genre3 === props.genre1 ||
            item.genres.genre3 === props.genre2 ||
            item.genres.genre3 === props.genre3
            ? item.name !== props.name && arr.indexOf(item.name) === -1
              ? arr.push(item.name) && (
                  <Link to={item.path} className={classes.link}>
                    <div className={classes.block} key={item.id}>
                      <img src={item.image} />
                      <p className={classes.genres}>
                        {item.genres.genre1}, {item.genres.genre2},{" "}
                        {item.genres.genre3}
                      </p>
                      <h5>{item.name}</h5>
                      <p className={classes.price}>{item.price}</p>
                      {/* {() => setCountOfAlb(countOfAlb + 1)} */}
                      {/* {setCountOfAlb((current) => current+1)}
                            {console.log(countOfAlb)} */}
                      <div className={classes.count}>{count1++}</div>
                    </div>
                  </Link>
                )
              : null
            : null
          : null
      )}
    </div>
  );
};

export default AlbumSmallAdd;
