import React from 'react';


const Path = (props) => {
    return (
        <div className="route-1">
          <p>
            {props.from} -&gt;
          </p>
          <p>
            {props.to}
          </p>
        </div>
    );
}

export default Path;