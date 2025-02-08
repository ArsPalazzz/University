import "./App_9.css";
import "react-responsive-carousel/lib/styles/carousel.min.css"; // requires a loader
import { Carousel } from "react-responsive-carousel";
import { useState } from "react";

function App_9() {
     const [TableData, setTableData] = useState([
          {
               price: 1003.00,
               price_end: 1399.00,
               image1: "https://img.5element.by/import/images/ut/goods/good_ee8f64a2-b564-11eb-bb92-0050560120e8/t40fsm6020-televizor-thomson-1_200.jpg",
               image2: "https://img.5element.by/import/images/ut/goods/good_ee8f64a2-b564-11eb-bb92-0050560120e8/t40fsm6020-televizor-thomson-2_200.jpg",
               image3: "https://sun9-79.userapi.com/s/v1/ig2/7nHZqC6n48IDFeefrUj2Zs2Kuje7q23_Lzj6hw3QG-rhT7ISSEkXdIgd6RQBJXoafYzzXgyD45N1fPVY8wS1pgaa.jpg?size=721x1600&quality=95&type=album",
               name: "Телевизор Thomson T40FSM6020",
               members: 25,
               character:
                    "Основные характеристики Smart TV: Да Тип экрана:  LCD Диагональ:  40  Разрешение:  Full HD-1920x1080 пикс. LED-подсветка:  Direct LED Операционная система:  Android TV",
               sale: 20 + "%",
               new: "Новинка",
          },
          {
               price: 1649.00,
               price_end: 1748.00,
               image1: "https://img.5element.by/import/images/ut/goods/good_448f34e1-7d9f-11eb-bb92-0050560120e8/43lm5772pla-televizor-lg-1_200.jpg",
               image2: "https://img.5element.by/import/images/ut/goods/good_448f34e1-7d9f-11eb-bb92-0050560120e8/43lm5772pla-televizor-lg-2_200.jpg",
               image3: "https://img.5element.by/import/images/ut/goods/good_448f34e1-7d9f-11eb-bb92-0050560120e8/43lm5772pla-televizor-lg-3_200.jpg",
               name: "Смарт-часы APPLE Watch SE GPS Gold Aluminium Case with Starlight Sport Band 40mm",
               members: 11,
               character:
               "Основные характеристики Smart TV: Да Тип экрана:  LCD Диагональ:  43  Разрешение:  Full HD-1920x1080 пикс. LED-подсветка:  Direct LED Операционная система:  WebOS",
               sale: 8 + "%",
               new: "Новинка",
          },
     ]);

     const [directionSort, setDirectionSort] = useState(true);

     const sortData = (field) => {
          const copyData = TableData.concat();

          let sortData;

          if (directionSort) {
               sortData = copyData.sort((a, b) => {
                    return a[field] > b[field] ? 1 : -1;
               });
          }
          sortData = copyData.reverse((a, b) => {
               return a[field] > b[field] ? 1 : -1;
          });
          setTableData(sortData);
          setDirectionSort(!directionSort);
     };

     return (
          <div className='App'>
               <div>
                    <button
                         class='button-28'
                         role='button'
                         onClick={() => sortData("price")}>
                         Цена
                    </button>
                    <button
                         class='button-28'
                         role='button'
                         onClick={() => sortData("name")}>
                         Название
                    </button>
                    <button
                         class='button-28'
                         role='button'
                         onClick={() => sortData("sale")}>
                         Скидка
                    </button>
                    <button
                         class='button-28'
                         role='button'
                         onClick={() => sortData("members")}>
                         Количество
                    </button>
               </div>
               {TableData.map((item) => (
                    <div className='component'>
                         <div className='img'>
                              <div>
                                   <div className='up_img'>
                                        <div className='new'>{item.new}</div>
                                        <div className='sale'>{item.sale}</div>
                                   </div>
                                   <div>
                                        <Carousel width='500px'>
                                             <div className='image'>
                                                  <img src={item.image1} />
                                             </div>
                                             <div className='image'>
                                                  <img src={item.image2} />
                                             </div>
                                             <div className='image'>
                                                  <img src={item.image3} />
                                             </div>
                                        </Carousel>
                                   </div>
                              </div>
                         </div>
                         <div className='opinion'>
                              <div>
                                   <div>
                                        <h3 className='name'>{item.name}</h3>
                                        <div className='priceList'>
                                             <span className='price'>
                                                  {item.price} Руб
                                             </span>
                                             <span className='price_end'>
                                                  {item.price_end} Руб
                                             </span>
                                        </div>
                                        <div className='members'>
                                             <span>
                                                  Количество {item.members} шт.
                                             </span>
                                        </div>
                                   </div>
                                   <div className='character'>
                                        {item.character}
                                   </div>
                              </div>
                         </div>
                    </div>
               ))}
          </div>
     );
}

export default App_9;
