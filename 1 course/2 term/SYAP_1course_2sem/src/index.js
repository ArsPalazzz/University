import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App_9 from './App_9';
import App_3 from './App_3';
import App_5 from './App_5';
import "react-phone-number-input/style.css";
import Proba from './proba';

ReactDOM.render(
  <React.StrictMode>
    <App_3 />
  </React.StrictMode>,
  document.getElementById('root')
);


/*
	6-3. Дан инпут и абзац. В инпут вводится возраст пользователя. Сделайте так, чтобы при наборе текста в абзаце автоматически появлялся год рождения пользователя.
*/

// class Tasks extends Component {
	
// 	state = {
// 		hrefs: [
// 			{href: '1.html', text: 'ссылка 1'},
// 			{href: '2.html', text: 'ссылка 2'},
// 			{href: '3.html', text: 'ссылка 3'},
// 		],
// 		textInp1: '',
// 		textInp2: ''
// 	}

// 	textInp1 = (event) => {
// 		this.setState({textInp1: event.target.value});
// 	}

// 	textInp2 = (event) => {
// 		this.setState({textInp2: event.target.value});
// 	}
	
// 	addItem = () =>{
// 		if (this.state.textInp1 === "" || this.state.textInp2 === "") {
//       		alert("All inputs must be completed");
//     } else {
//       this.state.hrefs.push({
//       	href: this.state.textInp1, 
//       	text: this.state.textInp2});
//       this.setState({ textInp1: "", textInp2: "" });
//     }
// 	}

// 	render(){
// 		const list = this.state.hrefs.map((item, index)=>{
// 			return <li key={index}><a href={item.href}>{item.text}</a></li>
// 		});
// 		return(
// 			<div>
// 				<ul>{list}</ul>
// 				<input value={this.state.textInp1} onChange={this.textInp1} type="text"/><br/>
// 				<input value={this.state.textInp2} onChange={this.textInp2} type="text"/><br/>
// 				<button onClick={this.addItem}>Add item</button>
// 			</div>
// 		);
// 	}
	
// }


//  ReactDOM.render(
//    <React.StrictMode>
//      <Tasks />
//    </React.StrictMode>,
//    document.getElementById('root')
//  );