import React from "react";
import "./Search.css"

export class Search extends React.Component {

    onChange = (e) => {
        this.setState(() => this.props.search(e.target.value));
    };
    onClick = (target) => {
        this.setState(() => this.props.searchParameter(target));
    };

    render() {
        return (
            <div className="search">
                <input className="search-input" type="search" placeholder="Поиск..." onChange={this.onChange}/>
                <div>
                <label>
                    <input
                        type="radio"
                        id="partial"
                        name="search"
                        defaultChecked
                        onClick={this.onClick.bind(this, "partial")}
                    />
                    Частичное совпадение
                </label>
                <label>
                    <input
                        type="radio"
                        id="full"
                        name="search"
                        onClick={this.onClick.bind(this, "full")}
                    />
                    Полное совпадение
                </label>
                </div>
            </div>
        );
    }
}