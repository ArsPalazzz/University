import React, {useState} from 'react'
import SignUpForm from "./Form/SignUpForm";
import StudentInfoHandler from "./StudentInfoHandler";

const StudentInfo = () => {
    const [studentInfo, setStudentInfo] = useState({
        name: '',
        surname: '',
        secondName: '',
        day: '',
        month: '',
        year: '',
        enterYear: '',
        faculty: '',
        group: '',
        spec: '',
        email: '',
        phoneNumber: ''
    })

    const onChangeHandle = (student) => {
        setStudentInfo(student)
    }

    return (
        <>
            <SignUpForm getInfo={onChangeHandle}/>
            <StudentInfoHandler info={studentInfo}/>
        </>
    )
}

export default StudentInfo