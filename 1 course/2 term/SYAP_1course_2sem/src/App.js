import React from 'react';
import './App.css';

class App extends React.Component {
  constructor(props) {
      super(props);
      this.state = {date: new Date()};
  }

  render() {
      return (
          <div>
              <h1>Hello, world!</h1>
              <h2>Сейчас {this.state.date.toLocaleTimeString()}.</h2>
          </div>
      );
  }
}


export default App;
