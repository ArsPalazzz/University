import React from 'react';
import classes from './../sassModules/Order.module.scss'
import {BiTrash} from 'react-icons/bi'
import { Link } from 'react-router-dom';

const Order = (props) => {
        return(
            <div className={classes.item}>
                <Link to='/orderPage' className={classes.linkStylesAbout}>
                    <img src={props.item.image} alt='albumPhoto'/>
                    <h2 className={classes.pInLink}>{props.item.name}</h2>
                    <p>{props.item.price}</p>
                </Link>
                <BiTrash className={classes.deleteIcon} onClick={ () => props.onDelete(props.item.id)}/>
            </div>
        );
}

export default Order;