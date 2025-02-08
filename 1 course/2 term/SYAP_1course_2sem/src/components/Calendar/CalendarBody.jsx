const CalendarBody = ({ currentMonthIndex, currentYear, handleDayClick, pickedDaysList, checkedDaysList }) => {
	const dateNow = new Date()

	// первые дни месяцев
	let prevMonthFirstDay = new Date(currentYear, currentMonthIndex - 1)
	let currentMonthFirstDay = new Date(currentYear, currentMonthIndex)
	let nextMonthFirstDat = new Date(currentYear, currentMonthIndex + 1)

	// индекс дня недели для первого числа
	let firstDayInMonthIndex = (currentMonthFirstDay.getDay() + 6) % 7

	// количество дней
	let currMonthDaysCount = (nextMonthFirstDat - currentMonthFirstDay) / (1000 * 3600 * 24)
	let prevMonthDaysCount = 	(currentMonthFirstDay - prevMonthFirstDay) / (1000 * 3600 * 24)

	// индекс дня в массиве дней
	let dayIndex = 1 - firstDayInMonthIndex

	// проверка на равенство текущему дню
	const checkCurrentDay = dateNow.getFullYear() === currentMonthFirstDay.getFullYear() &&
		dateNow.getMonth() === currentMonthFirstDay.getMonth()

	const CAL_ROWS = 6
	const CAL_COLS = 7
	let daysMatrix = [], row = []

	// заполнение матрицы дней
	for (let i = 0; i < CAL_ROWS; i++) {
        row = []
        for (let j = 0; j < CAL_COLS; j++) {
			row.push({
				date: new Date(currentYear, currentMonthIndex - 1, prevMonthDaysCount + dayIndex),
				classes: 'cell',
			})
			// текущий день
			if(dayIndex === dateNow.getDate() && checkCurrentDay)
				row[j].classes += ' curr'
			// дни прошлого и следующиего месяцев
			else if(dayIndex <= 0 || dayIndex > currMonthDaysCount)
				row[j].classes += ' none'
			// проверка выбранных дней
			pickedDaysList.forEach((day) => {
				if(row[j].date.getTime() === day.date.getTime()) {
					row[j].classes += ' checked'
				}
			})
			// проверка дней с заметками
			checkedDaysList.forEach((day) => {
				if(row[j].date.getTime() === day.day.getTime() && day.notes.length !== 0) {
					row[j].classes += ' noted'
				}
			})
			dayIndex++
        }
        daysMatrix.push(row)
    }

	return (
		<div className={'calBody'}>
			{
				daysMatrix.map((row) => {
					return row.map((cell, i) => {
						return <div key={i} className={cell.classes} onClick={() => handleDayClick(cell)}>{cell.date.getDate()}</div>
					})
				})
			}
		</div>
	)
}

export default CalendarBody
