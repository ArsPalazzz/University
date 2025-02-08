import React from 'react'

const Counter2 = (props) => {

    const [count, setCount] = React.useState(0);

    return (
        <div>
            <button onClick={() => setCount(count + 1)} value={count} >INc</button>
            <p data-testid="count">{count}</p>
            <button onClick={() => setCount(count - 1)} value={count} >Dec</button>
        </div>
    )
}

export default Counter2