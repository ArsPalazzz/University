import {SortTable} from "./SortTable/SortTable";
import React, {useRef, useState} from "react";
import {content} from "./SortTable/Content";
import {Search} from "./Search/Search";

export const Catalog = () => {


    const [array, setArray] = useState(content);
    const [search, setSearch] = useState('');
    const [sorted, setSorted] = useState({name: true, price: true, inStock: true, discount: true});
    const [searchParameter, setSearchParameter] = useState('partial');



    const sort = (byWhat) => {
        let direction = sorted[byWhat] ? 1 : -1,
            goodsCopy = [...array].sort(function (a, b) {
                if (a.new || b.new)
                    return 0
                if (a[byWhat] > b[byWhat]) {
                    return direction;
                }
                if (a[byWhat] < b[byWhat]) {
                    return direction * -1;
                }
                return 0;
            });
        sorted[byWhat] = !sorted[byWhat];
        setArray(goodsCopy);
    }
    const sorts = () => {
        return (
            <div className="sorts">
                <button onClick={() => sort("name")}>
                    Название
                </button>
                <button onClick={() => sort("price")}>
                    Цена
                </button>
                <button onClick={() => sort("inStock")}>
                    Количество 
                </button>
                <button onClick={() => sort("discount")}>
                    Скидка
                </button>
            </div>
        );
    }
    const goods = () => {

        return array
            .filter((item) => {
                if (!search) return item;
                switch (searchParameter) {
                    case "partial":
                        if (
                            item.name.toLowerCase().includes(search.toLowerCase())
                        ) {
                            return item;
                        }
                        break;
                    case "full":
                        if (item.name.toLowerCase() === search.toLowerCase()) {
                            return item;
                        }
                        break;
                    default:
                        return item;
                }
            })
            .map((item) => {
                return (
                    <div className="one_good">
                        <div className="wrapper">
                        <img src={item.img} alt=""/>
                        <div className="text">
                            <h2>{item.name}</h2>
                            {item.new ? <div className="new">New</div> : null}
                            <div className="prices">
                                {item.discount && <h2>{(item.price * (100 - item.discount)) / 100}$</h2>}
                                <h3>{item.price}$</h3>
                            </div>
                            <h3>{item.inStock} штук</h3>

                        </div>
                        </div>
                        <div className="description"><h3>Описание:</h3><span className="description-text">{item.desc}</span></div>
                    </div>
                );
            });
    }

    return (
        <>
            {sorts()}
            <Search search={setSearch} searchParameter={setSearchParameter} />
            <div className="goods">
                {goods()}
            </div>
        </>
    );
}