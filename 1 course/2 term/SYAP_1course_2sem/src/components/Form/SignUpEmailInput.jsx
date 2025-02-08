import React from 'react'
import {useState} from 'react'

const SignUpEmailInput = ({handler, email}) => {
	const [pClass, setPClass] = useState('')

	const onEmailInput = (e) => {
		let input = e.target
	
		if (input.value.match(/.@.+\..+/i)) { email('correct'); setPClass('correct') }
		else { email('input correct email'); setPClass('incorrect') }

		if(input.value === '') { email(''); setPClass('') }
	}

	return (
		<div className='inputPlaceholder'>
			<input
				className='input'
				type='text'
				placeholder='Почта'
				id={'em'}
				onInput={onEmailInput}
				onChange={handler}
			/>
			<p className={pClass}>{pClass}</p>
		</div>
	)
}

export default SignUpEmailInput
