import React from 'react';
import classes from '../sassModules/Footer.module.scss';
import youtube from '../images/other/youtube.svg';
import inst from '../images/other/inst.svg';
import vk from '../images/other/vk.svg';

const Footer = () => {
        return (
            <footer id="myFooter">
                <div className={classes.footerFlex}>
                    <div className={classes.part1}>
                        <div className={classes.part1Flex}>
                            <div className={classes.footInf}>
                                <div className={classes.footInfFlex}>
                                    <h2>More about us</h2>
                                    <p>Our performances are super mega cool. Our team is also super duper cool. <br/>And if you want to join it, contact us. We always welcome new friends </p>
                                </div>
                            </div>
                            <div className={classes.footCont}>
                                <div className={classes.footContFlex}>
                                    <div className={classes.phNemail}>
                                        <h2>Contacts</h2>
                                        <p>Phone Number: +375447325235<br/>Gmail: palaznika608@gmail.com</p>
                                    </div>
                                    <div className={classes.messages}>
                                        <div className={classes.messagesFlex}>
                                            <div className={classes.youtube}>
                                                <a href="https://www.youtube.com/channel/UC3XOkvjVjmmStZ2Ziyvy35w">
                                                    <img src={youtube} />
                                                </a>
                                            </div>
                                            <div className={classes.inst}>
                                                <a href="https://www.instagram.com/arspalazzz/?hl=ru">
                                                <img src={inst} />
                                                </a>
                                            </div>
                                            <div className={classes.vk}>
                                                <a href="https://vk.com/a.palaznik">
                                                <img src={vk} />
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className={classes.part2}>
                        <div className={classes.part2Flex}>
                            <p>Copyright &copy;  2022 - All Rights Reserved</p>
                        </div>
                    </div>
                </div>
            </footer>
        );
}

export default Footer;