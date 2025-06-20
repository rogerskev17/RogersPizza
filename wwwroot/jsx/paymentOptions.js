import React from 'react';
import { createRoot } from 'react-dom/client';

// document.body.innerHTML = '<div id="app"></div>';

// const root = createRoot(document.getElementById('app'));
// root.render(<p>Test</p>);
/*
const paymentOptions = ["Cash", "Credit Card"];

function DisplayPaymentDetails() {
    const [currentOption, setCurrentOption] = useState("Cash");
    const [showPaymentDetails, setPaymentDetails] = useState("false");

    const handleSelectChange = (event) => {
        setSelectedOption(event.target.value);
    };
}

function HandlePaymentDetails() {

}
*/
//require('./lib');

class PaymentOptions extends React.Component {
    render() {
        return (
            <div>
                <h1>You got it! Congratulations!</h1>
            </div>
        );
    }
}

const domNode = document.getElementById('payment-options');
if (domNode) {
    const root = createRoot(domNode);
    root.render(<PaymentOptions />);
}
// ReactDOM.render(<PaymentOptions />, document.getElementById('payment-options'));