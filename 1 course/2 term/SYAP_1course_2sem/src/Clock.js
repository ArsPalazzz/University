import React, { Component } from 'react';

export default class Clock extends Component {
    constructor(props) {
        super(props)
        this.state = {date: new Date()}
    }

    componentDidMount() {
        this.timerID = setInterval(
            () => this.tick(),
            1000
        );
    }

    componentWillUnmount() {
        clearInterval(this.timerID);
    }

    tick() {
        this.setState({
            date: new Date()
        });
    }

    render() {
        /*const TimeZone = this.props.format;
        let UTCFault = this.props.timezone;
        let date = new Date()
        UTCFault = UTCFault.replace(":", ".");
        date = new Date(Date.now() + date.getTimezoneOffset()*60000 + parseFloat(UTCFault) *3600000);
            if (TimeZone === '12') {
                return (this.state.date.toLocaleTimeString("en"));
            }
            else {
                return (this.state.date.toLocaleTimeString("ru"));
            }
        */

        const timeZone = this.props.timezone;
        let format = this.props.format;
        format = format.replace(':', '.');
        let date = new Date();
        date = new Date(Date.now() + date.getTimezoneOffset()*60000 + parseFloat(format) *3600000);
        if (format === '12') {
            return (parseInt(this.state.date.toLocaleTimeString('en')) - 3 + parseInt(timeZone) + ':' + this.state.date.getMinutes() + ':' + this.state.date.getSeconds());
        }
        else {
            if (parseInt(this.state.date.toLocaleTimeString('ru')) - 3 + parseInt(timeZone) > 24) {
                return (parseInt(this.state.date.toLocaleTimeString('ru')) - 3 - 24 + parseInt(timeZone) + ':' + this.state.date.getMinutes() + ':' + this.state.date.getSeconds());
            }
            else {
                return (parseInt(this.state.date.toLocaleTimeString('ru')) - 3 + parseInt(timeZone) + ':' + this.state.date.getMinutes() + ':' + this.state.date.getSeconds());
            }
        }
    }
}











// class Clock extends Component {
//     constructor(props) {
//         super(props);
//         this.state = {
//             time: this.toOffsetDate(this.props.offset)
//         };
//     }
//     componentDidMount() {
//         this.intervalID = setInterval(
//             () => this.tick(),
//             1000
//         );
//     }
//     componentWillUnmount() {
//         clearInterval(this.intervalID);
//     }

//     toOffsetDate(offset) {
//         var d = new Date(new Date().getTime() + (3600 * 1000));
//         var hrs = d.getUTCHours();
//         var mins = d.getUTCMinutes();
//         var secs = d.getUTCSeconds();
//         return `${hrs}:${mins}:${secs}`;

//     }

//     tick() {
//         this.setState({
//             time: this.toOffsetDate(this.props.offset)
//         });
//     }
//     render() {
//         return (
//             <p className="App-clock">
//                 {Clock.toOffsetDate(3600)}
//                 {/* <Clock offset="3600" /> */}
//                 {/* The time is {this.state.time}. */}
//             </p>
//         );
//     }
// }
