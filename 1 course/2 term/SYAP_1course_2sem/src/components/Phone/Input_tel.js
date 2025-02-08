import "./Input_tel.css";
import "./Input_list.css";
import React, { useState } from "react";


const Flags_data = [
     {
          url: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAABt0lEQVRIS2Ps4uevYGZjr/+aX8nGwMDAwDOpE0QxfHv18iWYQSPAysDwSpzhfzBjr6jYd0ZGJrYveeVgq+jlAJBdIEcwNrX0/wVxwo7vf8nw/z+D7Lp1YIdc5wAHCM3ADqjJCAcc2wcOcro7oE9MAhwC6Y8egx3wODiYARQSX7ZtoZnvQQbDQwDDAUFBYIvp5oDRNIAeBaDgfz93DsOL7Cw6p4EHD18yMDExvJs+jeFtZyfDnxfP6eOAFZ7+fxXPnmQQi4t/ySIlyfC2q4tBMC2d4XVTA30cAEqEqscOMmieOwXOhvwREQxi7Z0M1znpWBApnj3BoHv8MNgBgpmZDCLlFfQrCRcHhv9VO3qQQcDW9iWHri7D+xkzGAQzsxhe19fSJwpguSDtxq2XjFycDG86OxneT59Gv0SILRuCHEG3EGiaOPcZuDbctRFcB8AqI+6FrDSNAoYzEOMZ4Q7YuQEsQHcH9EtIgUMg7cFDsANgtaGG/2b6hACGA6C1Id0cMJoG+iWkLjIwMIh+rmwGxzlvO6QAKvQFJw3aAlaG54wTpKRc//9j6P1c2SxCVwewMjxnEGIIAwCfu+ioy0e8vgAAAABJRU5ErkJggg==",
          country_name: "Беларусь",
          county_code: "+375",
          formatNumber: "+375 (99) 999-99-99",
     },
     {
          url: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAo0lEQVRIS2PcuO+I+u07D/d/+/5DkoGOgIuT47mqirwjY8+spc/obTnMnyBHMDZNnPsfJFCcHkdH/zMw9M5cBLZv1AGjITDwIcCoWf+fhZWNwcotnq654NDW2ZBcMOqA0RAYDYEBD4HlAgzg2tBaRoKu5cDRJy8g5cCoA0ZDYDCEwGUGBgYdumYBhGXnGZdxM4gzsTHs+/+fQYvOjjj//zeDJwBxf34P7r+YUwAAAABJRU5ErkJggg==",
          country_name: "Российская Федерация",
          county_code: "+7",
          formatNumber: "+7 (999) 999-99-99",
     },
     {
          url: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAkElEQVRIS2Nk8JstzvKfcc9/BgYdBjoCRgaGK38Y/7swsvjOuUxvy2H+BDmCkdl3zn+QgKa5Kx39z8Bw/eRusH2jDhgNgdEQGA2BgQ+BUw0M4JLQ1JuRriXh6a1gaxkYRx0wGgKjITAaAoMhBC4z0LlFDC9yGRnOM55oZRBn+s2wj4GBQYuuZTEjw/l/LAyeAIt/eV49symwAAAAAElFTkSuQmCC",
          country_name: "Украина",
          county_code: "+380",
          formatNumber: "+380 (99) 999-99-99",
     },
     {
          url: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAlklEQVRIS2PcuO+I+u07D/d/+/5DkoGOgIuT47mqirwjY8+spc/obTnMnyBHMDZNnPsfJFCcHkdH/zMw9M5cBLZv1AGjITAaAqMhMPAhMJmBAVwSeqlK07Uk3Hb7KaQkHHXAaAiMhsBoCAx4CMxkZnr26+8/uraIYUUuOzPTE8aNvLzqL759PfDr7z8JepbFIMvFubhdABr9hiLY/1hmAAAAAElFTkSuQmCC",
          country_name: "Польша",
          county_code: "+48",
          formatNumber: "+48 999-999-999",
     },
     {
          url: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAYklEQVRYR2NkGGDAOMD2M4w6YDQEGD9sUw8ZyITI+HG7xv9RB4yGwICGwJ31OgObCPVy3EcdMBoCIzwEFqpbDGwIbJA3G3XAaAgMbAhMjTDfMqC14UBaDrJ7tFk+GgIDHgIAmVcsLny2L4UAAAAASUVORK5CYII=",
          country_name: "Литва",
          county_code: "+370",
          formatNumber: "+370 (99) 999-99-99",
     },
     {
          url: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAi0lEQVRIS2PsZhf0Zfz3bzYDI6M4Az3B//8v/zMxpTL2sPK/oLvlMI/+//+SsYdN4D+I76quSU//M+y+eR1s36gDRkNgNAQGPgSaJs79z87OxpAaHUrXcmDKvKWQcmDUAQMeAqN1wWgIjIbAaAgMaKOUgeEZI7hZzvBvDsN/RjG61kYMDM/+MzJmAABXiXXUUZYtcAAAAABJRU5ErkJggg==",
          country_name: "Латвия",
          county_code: "+371",
          formatNumber: "+371 9999-9999",
     },
];
const onPhoneInput = (e) => {}
function Input_tel({handler}) {
     const [menuActive, setMenuActive] = useState(false);
     const [imgActive, setImgActive] = useState(
          "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAABt0lEQVRIS2Ps4uevYGZjr/+aX8nGwMDAwDOpE0QxfHv18iWYQSPAysDwSpzhfzBjr6jYd0ZGJrYveeVgq+jlAJBdIEcwNrX0/wVxwo7vf8nw/z+D7Lp1YIdc5wAHCM3ADqjJCAcc2wcOcro7oE9MAhwC6Y8egx3wODiYARQSX7ZtoZnvQQbDQwDDAUFBYIvp5oDRNIAeBaDgfz93DsOL7Cw6p4EHD18yMDExvJs+jeFtZyfDnxfP6eOAFZ7+fxXPnmQQi4t/ySIlyfC2q4tBMC2d4XVTA30cAEqEqscOMmieOwXOhvwREQxi7Z0M1znpWBApnj3BoHv8MNgBgpmZDCLlFfQrCRcHhv9VO3qQQcDW9iWHri7D+xkzGAQzsxhe19fSJwpguSDtxq2XjFycDG86OxneT59Gv0SILRuCHEG3EGiaOPcZuDbctRFcB8AqI+6FrDSNAoYzEOMZ4Q7YuQEsQHcH9EtIgUMg7cFDsANgtaGG/2b6hACGA6C1Id0cMJoG+iWkLjIwMIh+rmwGxzlvO6QAKvQFJw3aAlaG54wTpKRc//9j6P1c2SxCVwewMjxnEGIIAwCfu+ioy0e8vgAAAABJRU5ErkJggg=="
     );
     const [formatNumber, setFormatNumber] = useState("+375 (99) 999-99-99");

     return (
          <div>
               <div className='react_input_tel'>
                    <InputMask
                         id='tel'
                         type='tel'
                         placeholder={formatNumber}
                         mask={formatNumber}
                         onInput={() => {
                              if (
                                   document
                                        .getElementById("tel")
                                        .value.replace(/[ ]/gi, "")
                                        .replace(/[_]/gi, "")
                                        .replace(/[(]/gi, "")
                                        .replace(/[)]/gi, "")
                                        .includes("+375")
                              ) {
                                   setImgActive(
                                        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAABt0lEQVRIS2Ps4uevYGZjr/+aX8nGwMDAwDOpE0QxfHv18iWYQSPAysDwSpzhfzBjr6jYd0ZGJrYveeVgq+jlAJBdIEcwNrX0/wVxwo7vf8nw/z+D7Lp1YIdc5wAHCM3ADqjJCAcc2wcOcro7oE9MAhwC6Y8egx3wODiYARQSX7ZtoZnvQQbDQwDDAUFBYIvp5oDRNIAeBaDgfz93DsOL7Cw6p4EHD18yMDExvJs+jeFtZyfDnxfP6eOAFZ7+fxXPnmQQi4t/ySIlyfC2q4tBMC2d4XVTA30cAEqEqscOMmieOwXOhvwREQxi7Z0M1znpWBApnj3BoHv8MNgBgpmZDCLlFfQrCRcHhv9VO3qQQcDW9iWHri7D+xkzGAQzsxhe19fSJwpguSDtxq2XjFycDG86OxneT59Gv0SILRuCHEG3EGiaOPcZuDbctRFcB8AqI+6FrDSNAoYzEOMZ4Q7YuQEsQHcH9EtIgUMg7cFDsANgtaGG/2b6hACGA6C1Id0cMJoG+iWkLjIwMIh+rmwGxzlvO6QAKvQFJw3aAlaG54wTpKRc//9j6P1c2SxCVwewMjxnEGIIAwCfu+ioy0e8vgAAAABJRU5ErkJggg=="
                                   );
                                   setFormatNumber("+999 (99) 999-99-99");
                              }
                              if (
                                   document
                                        .getElementById("tel")
                                        .value.replace(/[ ]/gi, "")
                                        .replace(/[_]/gi, "")
                                        .replace(/[(]/gi, "")
                                        .replace(/[)]/gi, "")
                                        .includes("+7")
                              ) {
                                   setImgActive(
                                        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAo0lEQVRIS2PcuO+I+u07D/d/+/5DkoGOgIuT47mqirwjY8+spc/obTnMnyBHMDZNnPsfJFCcHkdH/zMw9M5cBLZv1AGjITDwIcCoWf+fhZWNwcotnq654NDW2ZBcMOqA0RAYDYEBD4HlAgzg2tBaRoKu5cDRJy8g5cCoA0ZDYDCEwGUGBgYdumYBhGXnGZdxM4gzsTHs+/+fQYvOjjj//zeDJwBxf34P7r+YUwAAAABJRU5ErkJggg=="
                                   );
                                   setFormatNumber("+9 (99) 999-99-99");
                              }
                              if (
                                   document
                                        .getElementById("tel")
                                        .value.replace(/[ ]/gi, "")
                                        .replace(/[_]/gi, "")
                                        .replace(/[(]/gi, "")
                                        .replace(/[)]/gi, "")
                                        .includes("+380")
                              ) {
                                   setImgActive(
                                        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAkElEQVRIS2Nk8JstzvKfcc9/BgYdBjoCRgaGK38Y/7swsvjOuUxvy2H+BDmCkdl3zn+QgKa5Kx39z8Bw/eRusH2jDhgNgdEQGA2BgQ+BUw0M4JLQ1JuRriXh6a1gaxkYRx0wGgKjITAaAoMhBC4z0LlFDC9yGRnOM55oZRBn+s2wj4GBQYuuZTEjw/l/LAyeAIt/eV49symwAAAAAElFTkSuQmCC"
                                   );
                                   setFormatNumber("+999 (99) 999-99-99");
                              }
                              if (
                                   document
                                        .getElementById("tel")
                                        .value.replace(/[ ]/gi, "")
                                        .replace(/[_]/gi, "")
                                        .replace(/[(]/gi, "")
                                        .replace(/[)]/gi, "")
                                        .includes("+48")
                              ) {
                                   setImgActive(
                                        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAlklEQVRIS2PcuO+I+u07D/d/+/5DkoGOgIuT47mqirwjY8+spc/obTnMnyBHMDZNnPsfJFCcHkdH/zMw9M5cBLZv1AGjITAaAqMhMPAhMJmBAVwSeqlK07Uk3Hb7KaQkHHXAaAiMhsBoCAx4CMxkZnr26+8/uraIYUUuOzPTE8aNvLzqL759PfDr7z8JepbFIMvFubhdABr9hiLY/1hmAAAAAElFTkSuQmCC"
                                   );
                                   setFormatNumber("+99 (99) 999-99-99");
                              }
                              if (
                                   document
                                        .getElementById("tel")
                                        .value.replace(/[ ]/gi, "")
                                        .replace(/[_]/gi, "")
                                        .replace(/[(]/gi, "")
                                        .replace(/[)]/gi, "")
                                        .includes("+370")
                              ) {
                                   setImgActive(
                                        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAYklEQVRYR2NkGGDAOMD2M4w6YDQEGD9sUw8ZyITI+HG7xv9RB4yGwICGwJ31OgObCPVy3EcdMBoCIzwEFqpbDGwIbJA3G3XAaAgMbAhMjTDfMqC14UBaDrJ7tFk+GgIDHgIAmVcsLny2L4UAAAAASUVORK5CYII="
                                   );
                                   setFormatNumber("+999 (99) 999-99-99");
                              }
                              if (
                                   document
                                        .getElementById("tel")
                                        .value.replace(/[ ]/gi, "")
                                        .replace(/[_]/gi, "")
                                        .replace(/[(]/gi, "")
                                        .replace(/[)]/gi, "")
                                        .includes("+371")
                              ) {
                                   setImgActive(
                                        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAYCAYAAACbU/80AAAAi0lEQVRIS2PsZhf0Zfz3bzYDI6M4Az3B//8v/zMxpTL2sPK/oLvlMI/+//+SsYdN4D+I76quSU//M+y+eR1s36gDRkNgNAQGPgSaJs79z87OxpAaHUrXcmDKvKWQcmDUAQMeAqN1wWgIjIbAaAgMaKOUgeEZI7hZzvBvDsN/RjG61kYMDM/+MzJmAABXiXXUUZYtcAAAAABJRU5ErkJggg=="
                                   );
                                   setFormatNumber("+999 (99) 999-99-99");
                              }
                         }} onChange={handler}
                    />
                    <div
                         onClick={() => {
                              setMenuActive(!menuActive);
                         }}
                         className='select_flag'
                         style={{
                              backgroundImage: `url(${imgActive})`,
                              height: 30,
                              top: 486,
                              left: 90,
                              backgroundRepeat: "no-repeat",
                         }}>
                         <div className='input_flag'>
                              <div className='input_arrow'></div>
                         </div>
                    </div>
               </div>
               <div className={menuActive ? "menu active" : "menu"}>
                    <ul>
                         {Flags_data.map((item) => (
                              <li
                                   onClick={() => {
                                        setImgActive(item.url);
                                        document.getElementById("tel").value =
                                             item.county_code;
                                        setFormatNumber(item.formatNumber);
                                   }}>
                                   <div className='flags_div'>
                                        <div
                                             className='flags'
                                             style={{
                                                  backgroundImage: `url(${item.url})`,
                                                  backgroundRepeat: "no-repeat",
                                                  width: "25px",
                                                  height: "20px",
                                             }}></div>
                                        <span className='country'>
                                             {item.country_name}
                                        </span>
                                        <div className='country_code'>
                                             <span>{item.county_code}</span>
                                        </div>
                                   </div>
                              </li>
                         ))}
                    </ul>
               </div>
          </div>
     );
}

export default Input_tel;
