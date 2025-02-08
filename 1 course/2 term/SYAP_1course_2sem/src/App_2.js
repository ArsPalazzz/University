import React from 'react';
import Clock from './Clock';
import './App_2.css';
import clock2 from './clock2.gif';
import JobList from './JobList'
// import JobsList from './Components/JobsList';

function App_2() {
    const JobMenu = JobList.map(function(job){
        return (<li className="menu">{job.name}
        <ul className="second">
            <li><span>{job.site1}</span></li>
            <li>{job.site2}</li>
            <li>{job.site3}</li>
        </ul>
        </li>
        )
    }
    )
    return (
    <div className="content">
        <h1>Лабораторная работа №2</h1>
        <hr />
        <br />
        <br />
        <div className="content__clock">
            <div>
            <img src={clock2} />
            </div>
            <div className="content__time">
            <br /><br /><br />
            <hr />
            <h2>Время в Минске &#10145; <Clock format="24" timezone ="+3:00"/></h2>
            <h2>Время в Нью-Йорке &#10145; <Clock format="12" timezone="-4:00" /></h2>
            <h2>Время в Лондоне &#10145; <Clock format="12" timezone="+1:00" /></h2>
            <h2>Время в Пекине &#10145; <Clock format="24" timezone="+8:00" /></h2>
            <hr />
            </div>
        </div>
        <h2>Выберите вашу профессию</h2>
            <hr /><br />
        <div className="content__menu">
        <ol>
            {JobMenu}
        </ol>
        </div>
    </div>
    );
}

export default App_2






// export default class Clock extends React.Component {
//     render() {
//       return <div>Hello</div>;
//     }
//   }

// function App_2()
// {<Clock format='24' timezone='+3:00' />
//   return <div>
//     {hours}:{minuts}
//   </div>
// }
// function App_2(){
// function formatDate(date) {
//   return date.getFullYear() + '/' +
//     (date.getMonth() + 1) + '/' +
//     date.getDate() + ' ' +
//     date.getHours() + ':' +
//     date.getMinutes();
//  }
 
//  const seoul = new Date(1489199400000);
//  const ny = new Date(1489199400000 - (840 * 60 * 1000));
//  formatDate(seoul);  // 2017/3/11 11:30
//  formatDate(ny);     // 2017/3/10 21:30
// }
// export default App_2