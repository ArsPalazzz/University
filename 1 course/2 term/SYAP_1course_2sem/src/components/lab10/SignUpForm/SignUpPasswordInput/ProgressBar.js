export function ProgressBar({currentValue}) {
    return(
        <div className="formField ">
            <progress  className="progressBar" value={currentValue} max="100">
            </progress>
        </div>
    
    );
    }