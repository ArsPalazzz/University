import React, {useState} from 'react';
import Products from "./Products";


export default function Table() {
    // Объявление новой переменной состояния «data» и «order»
    const [data, setdata] = useState(Products); // хуки - функции которые помогают обрабатывать события в js
    const [order, setorder] = useState("ASC");  // assending - возрастающий
    const sorting = (col) => {
        if (order === "ASC") {
            const sorted = [...data].sort((a, b) =>
                a[col].toLowerCase() > b[col].toLowerCase() ? 1 : -1  //если a[col]>b[col] то эл-ты меняются местами
            );
            setdata(sorted);
            setorder("DSC");
        }
        if (order === "DSC") {
            const sorted = [...data].sort((a, b) =>
                a[col].toLowerCase() < b[col].toLowerCase() ? 1 : -1
            );
            setdata(sorted);
            setorder("ASC");
        }
    };
    return (
        <div className="container">
            <table className="product-table">
                <thead>
                    {/* <th></th> */}
                    <th onClick={()=>sorting("name")}>Name</th>
                    <th onClick={()=>sorting("price")}>Price</th>
                    <th onClick={()=>sorting("stock")}>Stock</th>
                </thead>
                <tbody>
                    {data.map((product)=>(
                        <tr key={product.id}>
                            {/* <td>{product.id}</td> */}
                            <td>{product.name}</td>
                            <td>{product.price}</td>
                            <td>{product.stock}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}