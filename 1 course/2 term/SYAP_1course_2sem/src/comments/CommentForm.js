import { useState } from "react";

const CommentForm = ({
     handleSubmit,
     submitLabel,
     hasCancelButton = false,
     handleCancel,
     initialText = "",
}) => {
     const [text, setText] = useState(initialText); //Хук - это специальная функция, которая позволяет «прицепиться» к возможностям React. 
     //Например, useState - это хук, который позволяет добавлять состояние React к компонентам-функциям
     const isTextareaDisabled = text.length === 0;
     const onSubmit = (event) => {
          event.preventDefault();
          handleSubmit(text);
          setText("");
     };
     return (
          <form onSubmit={onSubmit}>
               <textarea
                    className='comment-form-textarea'
                    value={text}
                    onChange={(e) => setText(e.target.value)}
               />
               <button
                    className='comment-form-button'
                    disabled={isTextareaDisabled}>
                    {submitLabel}
               </button>
               {hasCancelButton && (
                    <button
                         type='button'
                         className='comment-form-button comment-form-cancel-button'
                         onClick={handleCancel}>
                         Отменить
                    </button>
               )}
          </form>
     );
};

export default CommentForm;
