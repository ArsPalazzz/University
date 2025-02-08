import React, {useEffect, useState} from 'react';
import bel from 'https://phonoteka.org/uploads/posts/2022-09/1663712213_1-phonoteka-org-p-oboi-na-telefon-belarus-krasivo-1.jpg'
import rus from 'https://img2.goodfon.ru/original/960x800/9/b2/flag-rossiya-trikolor.jpg'
import ucr from 'https://besthqwallpapers.com/Uploads/26-5-2019/93998/flag-of-ukraine-4k-stone-background-grunge-flag-europe.jpg'
import lt from  'https://s1.slide-share.ru/s_slide/2810f3222de505a31371a00ae1636eeb/fc169ff6-63fa-420d-ad9a-c1ca4bf6e9ed.jpeg'
import lv from  'https://www.flagsflag.com/images/product/latvia-flags-and-pennants-78566.png'
import pl from  'https://static.vecteezy.com/system/resources/previews/001/176/916/large_2x/flag-of-poland-background-vector.jpg'

const SwitchFlag = ({id}) => {
    const [img, setImg] = useState(bel)

    useEffect(() => {
        switch (id){
            case 1:
                setImg(bel)
                break
            case 2:
                setImg(rus)
                break
            case 3:
                setImg(ucr)
                break
            case 4:
                setImg(pl)
                break
            case 5:
                setImg(lt)
                break
            case 6:
                setImg(lv)
                break;
            default:
                break;
        }
    }, [id])


    return (
        <img src={img} alt={'err'}/>
    );
};

export default SwitchFlag;