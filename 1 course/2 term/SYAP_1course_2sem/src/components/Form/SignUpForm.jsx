import React, {useState} from 'react'
import PhoneInput from './PhoneInput'
import SignUpEmailInput from './SignUpEmailInput'
import './style/SignUpForm.css'
import Input_tel from '../Phone/Input_tel'

const SignUpForm = ({getInfo}) => {
    const [studentInfo, setStudentInfo] = useState({})
    const [email, setEmail] = useState('')

    const days = [], years = []
    for (let i = 1; i < 32; i++) days.push(i)
    for (let i = 2022; i > 1950; i--) years.push(i)

    const months = [
        'January', 'February', 'March', 'April', 'May', 'June', 'July',
        'August', 'September', 'October', 'November', 'December'
    ]

    const allDays = days.map((day) => {
        return <option key={day}>{day}</option>
    })

    const allYears = years.map((year) => {
        return <option key={year}>{year}</option>
    })

    const allMonths = months.map((month, index) => {
        return <option id={(index + 1).toString()} key={index}>{month}</option>
    })

    const handler = (e) => {
        switch (e.target.id) {
            case 'nm':
                setStudentInfo({...studentInfo, name: e.target.value})
                break
            case 'srn':
                setStudentInfo({...studentInfo, surname: e.target.value})
                break
            case 'scn':
                setStudentInfo({...studentInfo, secondName: e.target.value})
                break
            case 'day':
                setStudentInfo({...studentInfo, day: e.target.value})
                break
            case 'month':
                setStudentInfo({...studentInfo, month: months.indexOf(e.target.value)})
                break
            case 'year':
                setStudentInfo({...studentInfo, year: e.target.value})
                break
            case 'ent':
                setStudentInfo({...studentInfo, enterYear: e.target.value})
                break
            case 'fc':
                setStudentInfo({...studentInfo, faculty: e.target.value})
                break
            case 'gr':
                setStudentInfo({...studentInfo, group: e.target.value})
                break
            case 'sp':
                setStudentInfo({...studentInfo, spec: e.target.value})
                break
            case 'em':
                setStudentInfo({...studentInfo, email: e.target.value})
                break
            case 'ph':
                setStudentInfo({...studentInfo, phoneNumber: e.target.value})
                break
            default:
                break
        }
    }

    const checkEmail = (value) => {
        setEmail(value)
    }

    const onSubmitForm = (e) => {
        e.preventDefault()

        if (email === 'correct' || email === '') {
            getInfo(studentInfo)
            e.target.reset()
        }
        else alert('Input correct email!')
    }

    // +++TODO: сохранять дату рождения в state
    // +++TODO: очистка формы: заполнить пустыми значениями
    // +++TODO: если email некорректный, то кнопка неактивна
    return (
        <form onSubmit={onSubmitForm}>
            <h2>Студент</h2>
            <input className={'input'} id={'nm'} placeholder={'Имя'} onChange={handler}/><br/>
            <input className={'input'} id={'srn'} placeholder={'Фамилия'} onChange={handler}/><br/>
            <input className={'input'} id={'scn'} placeholder={'Отчество'} onChange={handler}/><br/>
            <select className={'sel'} id={'day'} onChange={handler}>{allDays}</select>
            <select className={'sel'} id={'month'} onChange={handler}>{allMonths}</select>
            <select className={'sel'} id={'year'} onChange={handler}>{allYears}</select>
            <input className={'input'} id={'ent'} placeholder={'Год поступления'} onChange={handler}/><br/>
            <input className={'input'} id={'fc'} placeholder={'Факультет'} onChange={handler}/><br/>
            <input className={'input'} id={'gr'} placeholder={'Группа'} onChange={handler}/><br/>
            <input className={'input'} id={'sp'} placeholder={'Специальность'} onChange={handler}/><br/>
            <SignUpEmailInput handler={handler} email={checkEmail}/>
            <PhoneInput handler={handler}/>
            <input type={'submit'} className={'send'} value="send"/>
        </form>
    )
}

export default SignUpForm
