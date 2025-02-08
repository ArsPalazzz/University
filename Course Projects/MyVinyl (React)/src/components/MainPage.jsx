import React from "react";
import video from "./../videos/mainvideo.mp4";
import classes from "./../App.module.scss";
import { useState, useEffect } from "react";
import gladImg from "./../images/other/glad.jpg";
import addInfOne from "./../images/other/vinylsmain1.jpg";
import addInfTwo from "./../images/other/vinylsmain2.webp";
import { MdAddCircle } from "react-icons/md";
import { Link } from "react-router-dom";
import InfForPages from "./InfForPages";

const MainPage = (props) => {
  const [data, setdata] = useState(InfForPages); // хуки - функции которые помогают обрабатывать события в js

  const [value, setValue] = useState("");

  const filteredAlbums = data.slice(0, 12);

  let delay = 100;

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  return (
    <>
      <div className={classes.mainInf} id="myMainBlock">
        <video muted autoPlay loop className={classes.myvideo}>
          <source src={video} type="video/mp4" />
        </video>
        <p
          className={classes.myVinyl}
          data-aos="fade-right"
          data-aos-delay="300"
          data-aos-duration="1200"
        >
          MyVinyl
        </p>
        <p
          className={classes.theLargest}
          data-aos="fade-left"
          data-aos-delay="300"
          data-aos-duration="1200"
        >
          The largest selection of records
        </p>
      </div>
      <div className={classes.titleUpperAlbums}>The most recent records</div>
      <div className={classes.albums}>
        {filteredAlbums.map((item) => (
          <div
            className={classes.block}
            key={item.id}
            data-aos="fade-down"
            data-aos-delay={delay == 300 ? (delay = 100) : delay}
            data-aos-duration="800"
            data-aos-offset="-100"
          >
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
            <div className={classes.hideBlock}>{(delay += 50)}</div>
          </div>
        ))}
      </div>

      <Link to={"catalog"} className={classes.showAllLink}>
        <button className={classes.showAllBtn}>Show all</button>
      </Link>

      <div className={classes.gladBlock}>
        <img src={gladImg} alt="gladImg" />
        <p>We are always glad to see you</p>
      </div>
      <div className={classes.addInf}>
        <div className={classes.firstInf}>
          <div className={classes.firstInfImg}>
            <img src={addInfOne} alt="addInfOne" />
          </div>
          <div className={classes.firstInfText}>
            <h3>Play Vinyl Record Store</h3>
            <hr />
            <p>
              We are pleased to offer you a wide selection of vinyl at
              affordable prices. We regularly arrange discounts, promotions and
              sales. We sell only new and original records. Our main goal and
              fundamental principle in our work is customer satisfaction, since
              we do not sell music, we sell musical pleasure. We are ready to
              help you find even rare recordings! To do this, just leave a
              request. And we will do our best to help you get the desired
              record. We are friends with many "anonymous vinylers". These
              people, like us, depend on good music and are not going to be
              treated for their addiction!
            </p>
          </div>
        </div>
        <div className={classes.secondInf}>
          <div className={classes.secondInfText}>
            <h3>VMP Anthology: 50 years of the comedy store</h3>
            <hr />
            <p>
              A limited-edition vinyl box set featuring five albums and six LPs
              of comedy from the stage of the legendary comedy club on Sunset
              Boulevard. Produced in collaboration with the Comedy Store, '50
              Years of The Comedy Store' collects work from The Store’s various
              anniversary shows and presents them on vinyl for the first time
              ever.
            </p>
          </div>
          <div className={classes.secondInfImg}>
            <img src={addInfTwo} alt="addInfTwo" />
          </div>
        </div>
      </div>
    </>
  );
};

export default MainPage;
