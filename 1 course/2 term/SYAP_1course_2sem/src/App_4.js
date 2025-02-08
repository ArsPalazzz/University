import React, { useState } from 'react';
import Calendar from 'react-calendar';
import App from './App';
import 'react-calendar/dist/Calendar.css';

function App_4() {
  const [value, onChange] = useState(new Date());

  return (
    <div>
      <Calendar onChange={onChange} value={value} />
    </div>
  );
}

export default App_4
