import React from 'react';
import { useState, useEffect } from 'react';
import { createRoot } from 'react-dom/client';

export default function PaymentOptions() {
    const [paymentOption, setPaymentOption] = useState("cash");
    const [giftCardNumber, setGiftCardNumber] = useState("");

    useEffect(() => {
        const paymentTypeField = document.getElementById('Order.PaymentOption');
        const giftCardField = document.getElementById('Order.GiftCardNumber');

        if (paymentTypeField) {
            paymentTypeField.value = paymentOption;
        }        
        if (giftCardField) {
            giftCardField.value = giftCardNumber;            
        }
    }, [paymentOption, giftCardNumber]);

    const handlePaymentMethodChange = (e) => {
        setPaymentOption(e.target.value);
    };

    const handleGiftCardChange = (e) => {
        setGiftCardNumber(e.target.value);
    };

    return (
        <div>
            <div name="selectPaymentMethod">
                <p>Please select a payment method</p>
            </div>

            <select name="Order.PaymentOption" value={paymentOption} onChange={handlePaymentMethodChange}>
                <option value="cash">Cash</option>
                <option value="giftCard">Gift Card</option>
            </select>

            {paymentOption === "cash" &&
                <div name="cash">
                    <p>Please have your cash ready when receiving your order.</p>
                    <input type="hidden" name="Order.GiftCardNumber" value ="9999999999999999"/>
                </div>
                
            }

            {paymentOption === "giftCard" &&
                <div name="giftCardInput">
                    <p>Please enter your gift card number below.</p>
                    <input
                        type="text"
                        name="Order.GiftCardNumber"
                        id="giftCardInput"
                        inputmode="numeric"
                        placeholder="16-digit number only"
                        min="0"
                        minlength="16"
                        maxlength="16"
                        pattern="[0-9]{16}"
                        value={giftCardNumber}
                        onChange={handleGiftCardChange}
                        required
                    />
                </div>
            }
        </div>
    );
}

const domNode = document.getElementById('payment-options');
if (domNode) {
    const root = createRoot(domNode);
    root.render(<PaymentOptions />);
}