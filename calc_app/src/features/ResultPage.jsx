import React, {useState} from 'react';
import { getAveCubicWeight } from './../app/services/productService';

const ResultPage = () => {
    const [result, setResult] = useState();
    const [buttonShow, setButtonShow] = useState(true);

    const showResultHandler = async () => {
        let {data} = await getAveCubicWeight();
        setResult(data);
        setButtonShow(false);
    }

    const resultShowingStyle = {
        width: '60%',
        height: '50%',
        margin: '50px auto',
        padding: '200px',
        textAlign: 'center',
        backgroundColor: '#ccc',
        display: 'flex',
        'flexDirection': 'column',
        'alignItems': 'center',
        'justifyContent': 'spaceBetween',
    }

    const buttonStyle = {
        padding: '4px 16px',
        borderRadius: '3px',
        backgroundColor: '#ccc',
    }

    return (
        <div style={resultShowingStyle}>
            <h1>Average Cubic Weight: </h1>
            {result == null ? '' : <h2>{result}kg</h2> }
            {buttonShow && <button style={buttonStyle} onClick={showResultHandler}>Show Result</button>}
            
        </div>
    )
}

export default ResultPage
