import React from 'react'

const StudentInfoHandler = ({info}) => {
    const {
        name,
        surname,
        secondName,
        day,
        month,
        year,
        enterYear,
        faculty,
        group,
        spec,
        email,
        phoneNumber
    } = info

    let age = ''
    const dateOfBirth = new Date(Number(year), Number(month), Number(day))
    if (day && month && year)
    {
        age = Math.floor((new Date() - dateOfBirth) / (24 * 3600 * 365.25 * 1000))
        
    }
    //alert(age);

    let studCourse = ''
    if (enterYear)
        studCourse = new Date().getFullYear() - enterYear

    if(studCourse > 4)
        studCourse = 'Окончил'

    let emailOperator = ''
    if (email) emailOperator = email.split('@').pop()

    let phoneOperator = ''
    if (phoneNumber) {
        if (phoneNumber.match(/^\+375 \(29\) [1369]/) || phoneNumber.match(/^\+375 \(44\)/) || phoneNumber.match(/^8 029 [1369]/) || phoneNumber.match(/^8 044/))
            phoneOperator = 'A1 (Velcom)'
        if (phoneNumber.match(/^\+375 \(29\) [2578]/) || phoneNumber.match(/^\+375 \(33\)/) || phoneNumber.match(/^8 029 [2578]/) || phoneNumber.match(/^8 033/))
            phoneOperator = 'MTC'
        if (phoneNumber.match(/^\+375 \(25\)/) || phoneNumber.match(/^8 025/))
            phoneOperator = 'Life:)'
        if (phoneNumber.match(/^\+375 \(17\)/) || phoneNumber.match(/^8 017/))
            phoneOperator = 'Beltelecom'
    }

    return (
        <table style={{margin:'auto', backgroundColor:'royalblue',border:'grey'}}>
            <tbody>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>FIO</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{surname} {name} {secondName}</td>
            </tr>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>Age</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{age}</td>
            </tr>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>Faculty, course, group</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{faculty} {studCourse} {group}</td>
            </tr>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>Speciality</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{spec}</td>
            </tr>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>Email</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{email}</td>
            </tr>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>Email operator</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{emailOperator}</td>
            </tr>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>Phone number</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{phoneNumber}</td>
            </tr>
            <tr>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>Phone operator</td>
                <td style={{borderColor:'grey', borderWidth:'2px'}}>{phoneOperator}</td>
            </tr>
            </tbody>
        </table>
    )
}

export default StudentInfoHandler