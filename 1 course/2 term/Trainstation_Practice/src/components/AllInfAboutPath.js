import React from 'react';

let date = new Date();

const AllInfAboutPath = (props) => {
    return (
        <div key={props.id} className="route-1">
              <div className="data-1">
                <p>{date.getDate() + props.time} {props.month}</p>
                <p>{props.time1}</p>
                <p>{props.place1}</p>
              </div>
              <div className="data-2">
                <p>{props.time2}</p>
                <p>{props.cost}</p>
              </div>
              <div className="data-3">
                <p>{props.time3}</p>
                <p>{props.place2}</p>
              </div>
            </div>
    );
}

export default AllInfAboutPath;