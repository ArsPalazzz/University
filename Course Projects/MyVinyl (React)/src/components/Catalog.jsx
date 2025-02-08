import React, { useEffect } from "react";
import classes from "./../sassModules/Catalog.module.scss";
import findImage from "./../images/other/find.svg";
import { Genres } from "./Genres";
import { Link } from "react-router-dom";
import { useState } from "react";
import InfForPages from "./InfForPages";
import Slider from "react-slider";
import "./../sassModules/Slider.css";
import { FaChevronUp, FaChevronDown } from "react-icons/fa";
import ReactPaginate from "react-paginate";
import AlbumsForCatalog from "./AlbumsForCatalog";

const Catalog = (props) => {
  const priceArr = InfForPages.map((el) => Number(el.price.slice(0, -1)));
  const yearArr = InfForPages.map((el) => Number(el.year));

  const MinPrice = 0,
    MaxPrice = Math.max(...priceArr),
    MinYear = Math.min(...yearArr),
    MaxYear = Math.max(...yearArr);

  const [filterPrice, setFilterPrice] = useState([MinPrice, MaxPrice]);
  const [filterYear, setFilterYear] = useState([MinYear, MaxYear]);
  const [pageCount, setPageCount] = useState(0);

  const [isOpen, setIsOpen] = useState(true);

  const [selectedGenres, setSelectedGenres] = useState([]);
  const [value, setValue] = useState("");
  const [data] = useState(InfForPages); // хуки - функции которые помогают обрабатывать события в js
  const [isAllGenres, setIsAllGenres] = useState(false);

  //Sort
  const [upOrDownPrice, setUpOrDownPrice] = useState(false);
  const [upOrDownYear, setUpOrDownYear] = useState(false);
  const [upOrDownName, setUpOrDownName] = useState(false);

  const handleClickPrice = () => {
    sorting("price");
    setUpOrDownPrice((current) => !current);
  };

  const handleClickYear = () => {
    sorting("year");
    setUpOrDownYear((current) => !current);
  };

  const handleClickName = () => {
    sorting("name");
    setUpOrDownName((current) => !current);
  };

  const [order, setorder] = useState("ASC"); // assending - возрастающий
  const sorting = (col) => {
    if (order === "ASC") {
      const sorted = [...showedAlbums].sort(
        (a, b) => (a[col].toLowerCase() > b[col].toLowerCase() ? 1 : -1) //если a[col]>b[col] то эл-ты меняются местами
      );
      setShowedAlbums(sorted);
      setorder("DSC");
    }
    if (order === "DSC") {
      const sorted = [...showedAlbums].sort((a, b) =>
        a[col].toLowerCase() < b[col].toLowerCase() ? 1 : -1
      );
      setShowedAlbums(sorted);
      setorder("ASC");
    }
  };

  let genresList = [];

  Genres.forEach((value, key) => {
    genresList.push(
      <div key={key} className={classes.genre}>
        <input
          type="checkbox"
          className={classes.genreCheckbox}
          onClick={() => handleGenreClick(value)}
        />
        <label className={classes.genreLabel}> {value}</label>
      </div>
    );
  });

  const inputClickHandler = () => {
    setIsOpen(true);
  };

  const itemClickHandler = (e) => {
    setValue(e.target.textContent);
    setIsOpen(!isOpen);
  };

  const handleGenreClick = (genre) => {
    setSelectedGenres((prevSelectedGenres) => {
      if (!prevSelectedGenres.includes(genre)) {
        console.log("add");
        return [...prevSelectedGenres, genre];
      } else {
        console.log("remove");
        return prevSelectedGenres.filter(
          (selectedGenre) => selectedGenre !== genre
        );
      }
    });
  };

  const initFilteredAlbums = () => {
    return data.filter((album) => {
      return (
        album.name.toLowerCase().includes(value.toLowerCase()) &&
        album.year >= filterYear[0] &&
        album.year <= filterYear[1] &&
        Number(album.price.slice(0, -1)) >= filterPrice[0] &&
        Number(album.price.slice(0, -1)) <= filterPrice[1] &&
        (selectedGenres.length > 0
          ? selectedGenres.includes(album.genre1) ||
            selectedGenres.includes(album.genre2) ||
            selectedGenres.includes(album.genre3)
          : true)
      );
    });
  };

  useEffect(() => {
    setFilteredAlbums(initFilteredAlbums);
  }, [filterYear, filterPrice, selectedGenres, value]);

  const [filteredAlbums, setFilteredAlbums] = useState(data);

  const [showedAlbums, setShowedAlbums] = useState(filteredAlbums.slice(0, 10));
  const [currentPage, setCurrentPage] = useState(1);

  const handlePageClick = (data) => {
    setCurrentPage(data.selected + 1);
    console.log(currentPage);
    const albumsOnPage = 15;

    const showed = filteredAlbums.slice(
      0 + data.selected * albumsOnPage,
      albumsOnPage + data.selected * albumsOnPage
    );
    setShowedAlbums(showed);
    console.log(showed);
  };

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  useEffect(() => {
    setPageCount(Math.ceil(filteredAlbums.length / 15));
    // Здесь обновляйте showedAlbums на основе currentPage и filteredAlbums
    const albumsOnPage = 15;
    const startIndex = (currentPage - 1) * albumsOnPage;
    const endIndex = startIndex + albumsOnPage;
    const showed = filteredAlbums.slice(startIndex, endIndex);
    setShowedAlbums(showed);
  }, [currentPage, filteredAlbums]);

  return (
    <div>
      <div className={classes.main}>
        <p className={classes.breadcrumbs}>
          <Link to={"/"} className={classes.linkHome}>
            Home
          </Link>{" "}
          / Catalog
        </p>
        <p className={classes.centralText}>Catalog</p>
      </div>

      <div className={classes.cont}>
        <div className={classes.left}>
          <div className={classes.options}>
            <div className={classes.findBlock}>
              <form>
                <input
                  type="text"
                  placeholder="Search"
                  className={classes.searchInput}
                  onChange={(event) =>
                    setValue(event.target.value /*данные в input */)
                  }
                  value={value}
                  onClick={inputClickHandler}
                />
                <ul className={classes.autocomplete}>
                  {value && isOpen
                    ? showedAlbums.map((item) => {
                        return (
                          <li
                            className={classes.item}
                            onClick={itemClickHandler}
                            key={item.id}
                          >
                            {item.name}
                          </li>
                        );
                      })
                    : null}
                </ul>
                <img src={findImage} className={classes.findImg} />
              </form>
            </div>
            <div className={classes.genresBlock}>
              <div className={classes.genresList}>
                {" "}
                {isAllGenres ? genresList : genresList.slice(0, 5)}
              </div>
              <div
                onClick={(e) => setIsAllGenres((e) => !e)}
                className={classes.genresToggle}
              >
                Show all genres
              </div>
            </div>

            <div className={classes.priceBlock}>
              <p>Price</p>
              <Slider
                value={filterPrice}
                onChange={setFilterPrice}
                min={MinPrice}
                max={MaxPrice}
                step={0.01}
                className="priceRange"
              ></Slider>
              <div className={classes.prices}>
                <p>{filterPrice[0].toFixed(2)}</p>
                <p>{filterPrice[1].toFixed(2)}</p>
              </div>
            </div>
            <div className={classes.yearBlock}>
              <p>Year</p>
              <Slider
                value={filterYear}
                onChange={setFilterYear}
                min={MinYear}
                max={MaxYear}
                className="priceRange"
              ></Slider>
              <div className={classes.years}>
                <p>{filterYear[0]}</p>
                <p>{filterYear[1]}</p>
              </div>
            </div>
          </div>
        </div>
        <div className={classes.right}>
          <div className={classes.words}>
            <div onClick={handleClickName}>
              <p className={classes.name}>Name</p>
              {upOrDownName ? (
                <FaChevronUp className={classes.up1} />
              ) : (
                <FaChevronDown className={classes.down1} />
              )}
            </div>
            <div onClick={handleClickPrice}>
              <p className={classes.price}>Price</p>
              {upOrDownPrice ? (
                <FaChevronUp className={classes.up2} />
              ) : (
                <FaChevronDown className={classes.down2} />
              )}
            </div>
            <div onClick={handleClickYear} className={classes.yearBlock}>
              <p className={classes.year}>Year of publication</p>
              {upOrDownYear ? (
                <FaChevronUp className={classes.up3} />
              ) : (
                <FaChevronDown className={classes.down3} />
              )}
            </div>
          </div>

          <AlbumsForCatalog onAdd={props.onAdd} albums={showedAlbums} />

          <ReactPaginate
            prevPageRel={"Previous"}
            nextPageRel={"Next"}
            pageCount={pageCount}
            onPageChange={handlePageClick}
            containerClassName={classes.pagination}
            pageClassName={classes.pageItem}
            pageLinkClassName={classes.pageLink}
            previousClassName={classes.pageItem}
            previousLinkClassName={classes.pageLink}
            nextClassName={classes.pageItem}
            nextLinkClassName={classes.pageLink}
            breakClassName={classes.pageItem}
            breakLinkClassName={classes.pageLink}
            activeClassName={classes.active}
          />
        </div>
      </div>
    </div>
  );
};

export default Catalog;
