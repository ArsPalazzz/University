import React from "react";
import classes from "./../sassModules/AlbumsForCatalog.module.scss";
import { MdAddCircle } from "react-icons/md";
import { Link } from "react-router-dom";

const AlbumsForCatalog = (props) => {
  return (
    <div className={classes.albums}>
      {props.albums.length !== 0 ? (
        props.albums.map((item) => (
          <div className={classes.block} key={item.id}>
            <Link to={item.path} className={classes.link}>
              <div className={classes.first}>
                <img src={item.image} alt="albumPhoto" />
              </div>
            </Link>
            <MdAddCircle
              className={classes.add}
              onClick={() => props.onAdd(item)}
            />

            <div className={classes.second}>
              <Link to={item.path} className={classes.link}>
                <p className={classes.pInLink}>{item.name} [LP]</p>
              </Link>
              <p>{item.year}</p>
              <p>{item.price}</p>
            </div>
          </div>
        ))
      ) : (
        <p>Oops! We don't have such products, try changing the search terms.</p>
      )}
    </div>
  );
};

export default AlbumsForCatalog;
