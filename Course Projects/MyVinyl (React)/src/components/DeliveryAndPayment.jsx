import React from 'react'
import classes from './../sassModules/DeliveryAndPayment.module.scss'
import where1 from './../images/other/where1.jpg'
import where2 from './../images/other/where2.jpg'


const DeliveryAndPayment = () => {
    return (
        <div className={classes.container1}>
            <div className={classes.container2}>
                <div className={classes.inf1}>
                    <h1>Delivery and Payment</h1>
                    <p><b>The address</b> of the store is Stolitsa shopping center (3/2 Nezavisimosti Ave.), middle floor, 519</p>
                    <p><b>Opening hours</b> daily 10AM — 10PM</p>
                    <p><b>Phone Number</b> +375 44 539-22-47, +375 29 646-38-83</p>
                    <p className={classes.lenin}><b>Lenin Square metro station</b>, exit towards Independence Square. On the street, turn right and enter the pedestrian crossing. You will see the main entrance to the Stolitsa shopping center. After entering, turn right, go down one floor, and then go to the right side to the end (our store is behind Galanteya).</p>
                </div>
                <div className={classes.images}>
                    <img src={where1} />
                    <img src={where2} />
                </div>
                <p className={classes.text2}>Below is a map that shows the store and a map of the passage from the subway. The arrows indicate the descents of the stairs. You can set a route to travel from anywhere in Minsk here (click route).</p>

                <div className={classes.mapResponsive}>
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3599.6951414993923!2d27.543120089472914!3d53.8957194140409!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x46dbcfe7142b4247%3A0x3b3e86da335d7597!2z0KHRgtC-0LvQuNGG0LA!5e0!3m2!1sru!2sby!4v1670757863792!5m2!1sru!2sby" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                </div>
            </div>
        </div>
    )
}

export default DeliveryAndPayment