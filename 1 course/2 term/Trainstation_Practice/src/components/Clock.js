import React, {Component} from 'react';

class Clock extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            time : new Date()
        };
    }

    componentDidMount() {
        this.timeId = setInterval( () => {
            this.setState( {
                time : new Date()
            })
        }, 1000);
    }

    componentWillMount() {
        clearInterval(this.timeId)
    }

    render() {
        return (
            <div className='clockNcity'>
                <div className='clock'>
                    <div className='hour_hand'
                    style={{transform: `rotateZ(${(this.state.time.getHours() + parseInt(this.props.time, 10) - 3) * 30}deg)`}}>
                    </div>
                    <div className='minute_hand'
                    style={{transform: `rotateZ(${this.state.time.getMinutes() * 6}deg)`}}>                
                    </div>
                    <div className='second_hand'
                    style={{transform: `rotateZ(${this.state.time.getSeconds() * 6}deg)`}}>       
                    </div>

                    <span className='twelve'>12</span>
                    <span className='one'>1</span>
                    <span className='two'>2</span>
                    <span className='three'>3</span>
                    <span className='four'>4</span>
                    <span className='five'>5</span>
                    <span className='six'>6</span>
                    <span className='seven'>7</span>
                    <span className='eight'>8</span>
                    <span className='nine'>9</span>
                    <span className='ten'>10</span>
                    <span className='eleven'>11</span>
                </div>

                <div className='city'>
                    <h2>{this.props.cities}</h2>
                </div>
            </div>
        )
    }
}

export default Clock;