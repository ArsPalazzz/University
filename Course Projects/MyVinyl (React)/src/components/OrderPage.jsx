import classes from "./../sassModules/OrderPage.module.scss";
import { useState, useEffect } from "react";
import samovivoz from "./../images/other/samovivor.jpg";
import kurier from "./../images/other/kurier.jpg";
import cash from "./../images/other/cash.jpg";
import creditCard from "./../images/other/creditCard.png";
import Counter from "./Counter";
import InfForPages from "./InfForPages";
import AlbumSmallAdd from "./AlbumSmallAdd";
import { Link } from "react-router-dom";
import PhoneInput from "react-phone-number-input";
import "react-phone-number-input/style.css";
import scssStyle from "./../sassModules/PhoneInput.module.scss";
import cssStyleh1 from "./../sassModules/OrderPageh3.module.css";
// import storeOnMap from "./../images/other/storeOnMap.png";

const useValidation = (value, validations) => {
  const [isEmpty, setEmpty] = useState(true);
  const [minLengthError, setMinLengthError] = useState(false);
  const [maxLengthError, setMaxLengthError] = useState(false);
  const [emailError, setEmailError] = useState(false);
  const [inputValid, setInputValid] = useState(false);

  useEffect(() => {
    for (const validation in validations) {
      switch (validation) {
        case "minLength":
          value.length < validations[validation] && value.length !== 0
            ? setMinLengthError(true)
            : setMinLengthError(false);
          break;
        case "isEmpty":
          value ? setEmpty(false) : setEmpty(true);
          break;
        case "maxLength":
          value.length > validations[validation]
            ? setMaxLengthError(true)
            : setMaxLengthError(false);
          break;
        case "isEmail":
          const re =
            /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          re.test(String(value).toLowerCase())
            ? setEmailError(false)
            : setEmailError(true);
          break;
        default:
          return true;
      }
    }
  }, [value, validations]);

  useEffect(() => {
    if (isEmpty || maxLengthError || minLengthError || emailError) {
      setInputValid(false);
    } else {
      setInputValid(true);
    }
  }, [isEmpty, maxLengthError, minLengthError, emailError]);

  return {
    isEmpty,
    minLengthError,
    emailError,
    maxLengthError,
    inputValid,
  };
};

const useInput = (InitialValue, validations) => {
  const [value, setValue] = useState(InitialValue);
  const [isDirty, setDirty] = useState(false);

  const valid = useValidation(value, validations);

  const onChange = (e) => {
    setValue(e.target.value);
  };

  const onBlur = (e) => {
    setDirty(true);
  };

  return {
    value,
    onChange,
    onBlur,
    isDirty,
    ...valid,
  };
};

const OrderPage = (props) => {
  const [deliveryWasChoosen, setDeliveryWasChoosen] = useState(false);
  const [paymentWasChoosen, setPaymentWasChoosen] = useState(false);

  // хуки для нажатия на кнопки
  const [openCurier, setOpenCurier] = useState(true);
  const [openPickup, setOpenPickup] = useState(false);
  const [openCash, setOpenCash] = useState(true);
  const [openCredit, setOpenCredit] = useState(false);

  const [optionValue, setOptionValue] = useState(0);

  const [blockBut, setBlockBut] = useState(true);

  const setPressedState1 = (current) => {
    setOpenCurier((current) => !current);
    setOpenPickup((current) => !current);
  };

  const setPressedState2 = (current) => {
    setOpenCash((current) => !current);
    setOpenCredit((current) => !current);
  };

  // блок ф-ий для добавления 15р при выборе доставки курьером
  let clickNum = 0;
  let deliveryCost = 15;

  const addFullCost = (current) => {
    clickNum++;
    console.log(clickNum);
    if (clickNum % 2 === 1) {
      setOptionValue((current) => deliveryCost);
      setOpenCurier(true);
      setOpenPickup(false);
    }
    if (clickNum % 2 === 0) {
      setOptionValue((current) => 0);
      setOpenPickup(true);
      setOpenCurier(false);
    }
  };

  const deleteFullCost = (current) => {
    setOptionValue((current) => 0);
  };

  const setFullState1 = (current) => {
    setDeliveryWasChoosen(true);
    deleteFullCost();
    setPressedState1();
  };

  const setFullState2 = (current) => {
    setDeliveryWasChoosen(true);
    addFullCost();
    setPressedState1();
  };

  const setFullState3 = (current) => {
    setPaymentWasChoosen(true);
    setPressedState2();
  };

  const setFullState4 = (current) => {
    setPaymentWasChoosen(true);
    setPressedState2();
  };

  let allAllCost = 0;

  props.orders.map((e) => {
    allAllCost += parseFloat(e.price) * e.count;
  });

  const [items, setItems] = useState(InfForPages);

  const handleIncreaseCount = (id) => {
    //увеличение counter'а
    setItems(
      items.map((item) => {
        if (item.id === id) {
          item.count++;
        }
        return item;
      })
    );
  };

  const handleDecreaseCount = (id) => {
    //уменьшение counter'а
    setItems(
      items.map((item) => {
        if (item.id === id && item.count > 0) {
          item.count--;
        }
        return item;
      })
    );
  };

  const [numberValue, setNumberValue] = useState(""); //телефон

  //валидация

  const name = useInput("", { isEmpty: true, minLength: 2, maxLength: 20 });
  const email = useInput("", { isEmpty: true, minLength: 5, isEmail: true });
  const surname = useInput("", { isEmpty: true, minLength: 2, maxLength: 20 });

  // const [phoneValue, setPhoneValue] = useState('')
  // const [isDirtyPhone, setDirtyPhone] = useState(false)
  // const [isEmptyPhone, setIsEmptyPhone] = useState(true)

  // const handleEmpty = (e) => {
  //     isEmptyPhone ? setIsEmptyPhone(false) : setIsEmptyPhone(true)
  // }

  // const [openCurier, setOpenCurier] = useState(false)
  // const [openPickup, setOpenPickup] = useState(false)

  return (
    <>
      <div className={classes.containerUp}>
        <div className={classes.allInput}>
          <div className={classes.first}>
            <h3>1. Contact data</h3>

            {name.isDirty && name.isEmpty ? (
              <div className={cssStyleh1.emptyFirst}>
                The field cannot be empty
              </div>
            ) : null}
            {name.isDirty && name.minLengthError ? (
              <div className={cssStyleh1.minFirst}>
                The field must contain at least 2 symbols
              </div>
            ) : null}
            {name.isDirty && name.maxLengthError ? (
              <div className={cssStyleh1.maxFirst}>
                The field must contain a maximum of 25 symbols
              </div>
            ) : null}

            <input
              className={classes.inp1}
              onChange={(e) => name.onChange(e)}
              onBlur={(e) => name.onBlur(e)}
              value={name.value}
              type="text"
              placeholder="Name"
              name="name"
            />

            {surname.isDirty && surname.isEmpty ? (
              <div className={cssStyleh1.emptySecond}>
                The field cannot be empty
              </div>
            ) : null}
            {surname.isDirty && surname.minLengthError ? (
              <div className={cssStyleh1.minSecond}>
                The field must contain at least 2 symbols
              </div>
            ) : null}
            {surname.isDirty && surname.maxLengthError ? (
              <div className={cssStyleh1.maxSecond}>
                The field must contain a maximum of 25 symbols
              </div>
            ) : null}
            <input
              type="text"
              placeholder="Surname"
              className={classes.inp2}
              onChange={(e) => surname.onChange(e)}
              onBlur={(e) => surname.onBlur(e)}
              value={surname.value}
              rows="3"
              name="surname"
            />

            {email.isDirty && email.emailError ? (
              <div className={cssStyleh1.emailError}>Invalid email</div>
            ) : null}
            {email.isDirty && email.isEmpty ? (
              <div className={cssStyleh1.emptyThird}>
                The field cannot be empty
              </div>
            ) : null}
            {email.isDirty && email.minLengthError ? (
              <div className={cssStyleh1.minThird}>
                The field must contain at least 5 symbols
              </div>
            ) : null}

            <input
              className={classes.inp3}
              onChange={(e) => email.onChange(e)}
              onBlur={(e) => email.onBlur(e)}
              value={email.value}
              type="email"
              placeholder="Email"
              name="email"
            />

            <PhoneInput
              className={scssStyle.phoneInput}
              placeholder="Phone number"
              onChange={(e) => setNumberValue(e)}
              // onBlur={e => setDirtyPhone(true)}
              value={numberValue}
            />
            {/* {isDirtyPhone &&  (isEmptyPhone ? setIsEmptyPhone(false) : setIsEmptyPhone(true)) ? <div style={{color: 'red', backgroundColor: 'white',top: '34vh', left: '25vw', fontSize: '0.8vw', position:'absolute'}}>The field cannot be empty</div> : null} */}
          </div>
          <div className={classes.second}>
            <h3>2. Delivery</h3>
            <div className={classes.chooseDeliveryBlock}>
              <div
                className={classes.firstBlock}
                style={
                  openCurier
                    ? { border: "none" }
                    : { boxSizing: "content-box", boxShadow: "0 0 15px black" }
                }
              >
                <button onClick={setFullState2} className={classes.kurierBlock}>
                  <img
                    src={kurier}
                    alt=""
                    className={classes.kurierImg}
                    style={
                      openCurier
                        ? {
                            opacity: "1",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.0)",
                          }
                        : {
                            opacity: "0.4",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.2)",
                          }
                    }
                  />
                  <div
                    className={classes.textUponImg}
                    style={openCurier ? { pointerEvents: "none" } : {}}
                  >
                    <h3>By curier</h3>
                    <p
                      style={
                        openCurier
                          ? {
                              opacity: "1",
                              WebkitTransform: "translate3d(120%,0,0)",
                            }
                          : {
                              opacity: "1",
                              WebkitTransform: "translate3d(0%,0,0)",
                              transform: "translate3d(0,0,0)",
                            }
                      }
                    >
                      The goods will be delivered the next day
                      <br />
                      The shipping cost is 15$
                    </p>
                  </div>
                </button>
              </div>
              <div
                className={classes.secondBlock}
                style={
                  openPickup
                    ? { border: "none" }
                    : { boxSizing: "content-box", boxShadow: "0 0 15px black" }
                }
              >
                <button
                  onClick={setFullState1}
                  className={classes.samovivozBlock}
                >
                  <img
                    src={samovivoz}
                    alt=""
                    className={classes.samovivozImg}
                    style={
                      openPickup
                        ? {
                            opacity: "1",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.0)",
                          }
                        : {
                            opacity: "0.4",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.2)",
                          }
                    }
                  />
                  <div
                    className={classes.textUponImg}
                    style={openPickup ? { pointerEvents: "none" } : {}}
                  >
                    <h3 className="delivery-button-h3">Pickup</h3>
                    <p
                      style={
                        openPickup
                          ? {
                              opacity: "1",
                              WebkitTransform: "translate3d(120%,0,0)",
                            }
                          : {
                              opacity: "1",
                              WebkitTransform: "translate3d(10%,0,0)",
                              transform: "translate3d(10%,0,0)",
                            }
                      }
                    >
                      Pick up the goods at the address praspiekt Niezaliežnasci,
                      3/2
                    </p>
                  </div>
                </button>
              </div>
            </div>
          </div>
          <div className={classes.third}>
            <h3>3. Payment</h3>
            <div className={classes.choosePaymentBlock}>
              <div
                className={classes.firstBlock}
                style={
                  openCash
                    ? { border: "none" }
                    : { boxSizing: "content-box", boxShadow: "0 0 15px black" }
                }
              >
                <button onClick={setFullState4} className={classes.cashBlock}>
                  <img
                    src={cash}
                    alt=""
                    className={classes.cashImg}
                    style={
                      openCash
                        ? {
                            opacity: "1",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.0)",
                          }
                        : {
                            opacity: "0.4",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.2)",
                          }
                    }
                  />
                  <div
                    className={classes.textUponImg}
                    style={openCash ? { pointerEvents: "none" } : {}}
                  >
                    <h3>Cash</h3>
                    <p
                      style={
                        openCash
                          ? {
                              opacity: "1",
                              WebkitTransform: "translate3d(120%,0,0)",
                            }
                          : {
                              opacity: "1",
                              WebkitTransform: "translate3d(0%,0,0)",
                              transform: "translate3d(0,0,0)",
                            }
                      }
                    >
                      Pay in cash
                    </p>
                  </div>
                </button>
              </div>
              <div
                className={classes.secondBlock}
                style={
                  openCredit
                    ? { border: "none" }
                    : { boxSizing: "content-box", boxShadow: "0 0 15px black" }
                }
              >
                <button
                  onClick={setFullState3}
                  className={classes.creditCardBlock}
                >
                  <img
                    src={creditCard}
                    alt=""
                    className={classes.creditCardImg}
                    style={
                      openCredit
                        ? {
                            opacity: "1",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.0)",
                          }
                        : {
                            opacity: "0.4",
                            WebkitTransform: "translate3d(0,0,0)",
                            transform: "scale(1.2)",
                          }
                    }
                  />
                  <div
                    className={classes.textUponImg}
                    style={openCredit ? { pointerEvents: "none" } : {}}
                  >
                    <h3 className="delivery-button-h3">Credit card</h3>
                    <p
                      style={
                        openCredit
                          ? {
                              opacity: "1",
                              WebkitTransform: "translate3d(120%,0,0)",
                            }
                          : {
                              opacity: "1",
                              WebkitTransform: "translate3d(10%,0,0)",
                              transform: "translate3d(10%,0,0)",
                            }
                      }
                    >
                      Pay with a credit card
                    </p>
                  </div>
                </button>
              </div>
            </div>
          </div>
          <div className={classes.acceptCheck}>
            <input
              type="checkbox"
              className={classes.checkBut}
              onClick={() => setBlockBut((current) => !current)}
            />
            <p className={classes.text}>
              I accept the offer agreement, privacy policy and the rules for
              processing personal data
            </p>
          </div>
          <div className={classes.acceptButton}>
            <h4 className="delivery-cost-h4">
              Total cost(with delivery): {(allAllCost + optionValue).toFixed(2)}
              $
            </h4>
            <Link to="*" className={classes.link}>
              <input
                disabled={
                  !deliveryWasChoosen ||
                  blockBut ||
                  !name.inputValid ||
                  !email.inputValid ||
                  !surname.inputValid
                    ? "disabled"
                    : ""
                }
                form="contatcs-form"
                className={classes.subm}
                style={
                  !deliveryWasChoosen ||
                  blockBut ||
                  !name.inputValid ||
                  !email.inputValid ||
                  !surname.inputValid
                    ? {
                        backgroundColor: "gray",
                        color: "black",
                        cursor: "default",
                      }
                    : null
                }
                type="submit"
                value="Checkout"
              />
            </Link>
          </div>
        </div>
        <div className={classes.bagInf}>
          <div className={classes.text}>
            <p className={classes.count}>Your Items({props.orders.length})</p>
            <p>Total Cost: {allAllCost.toFixed(2)}$</p>
          </div>
          <div className={classes.allTheAlb}>
            {props.orders.map((item) => {
              return (
                <div className={classes.cont}>
                  <div className={classes.up}>
                    <div className={classes.imageBlock}>
                      <img src={item.image} />
                    </div>
                    <div className={classes.inf}>
                      <div className={classes.nameArticleCost}>
                        <div className={classes.nameArticle}>
                          <p className={classes.name}>{item.name}</p>
                          <p className={classes.article}>{item.article}</p>
                        </div>
                        <div className={classes.onlyCost}>
                          <p className={classes.cost}>
                            Album's cost: {item.price}
                          </p>
                        </div>
                      </div>
                      <div className={classes.costCount}>
                        <p>
                          Albums cost:{" "}
                          {(parseFloat(item.price) * item.count).toFixed(2)}$
                        </p>
                        <Counter
                          count={item.count}
                          id={item.id}
                          increase={handleIncreaseCount}
                          decrease={handleDecreaseCount}
                        />
                      </div>
                    </div>
                  </div>
                  <div className={classes.down}>
                    <p>
                      Genres: {item.genre1}, {item.genre2}, {item.genre3}
                    </p>
                    <p>Year: {item.year}</p>
                  </div>
                </div>
              );
            })}
          </div>
        </div>
      </div>
      <div className={classes.related}>
        <h2 className={classes.text}>Related Products</h2>
        <AlbumSmallAdd
          genre1={props.orders[0].genre1}
          genre2={props.orders[0].genre2}
          genre3={props.orders[0].genre3}
          name={props.orders[0].name}
        />
      </div>
    </>
  );
};

export default OrderPage;
