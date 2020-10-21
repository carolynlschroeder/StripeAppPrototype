$(function () {
    var stripe = Stripe($("#StripePublishableKey").val());
    var elements = stripe.elements();
    var style = {
        base: {
            iconColor: '#666EE8',
            color: '#31325F',
            lineHeight: '40px',
            fontWeight: 300,
            fontFamily: 'Helvetica Neue',
            fontSize: '15px',

            '::placeholder': {
                color: '#CFD7E0'
            }
        }
    };
    var cardNumberElement = elements.create('cardNumber', {
        style: style
    });
    cardNumberElement.mount('#card-number-element');

    var cardExpiryElement = elements.create('cardExpiry', {
        style: style
    });
    cardExpiryElement.mount('#card-expiry-element');

    var cardCvcElement = elements.create('cardCvc', {
        style: style
    });
    cardCvcElement.mount('#card-cvc-element');


    var form = document.getElementById('payment-form');
    form.addEventListener('submit',
        function(e) {
            var buttons = $(this).find('[type="submit"]');
            buttons.each(function(btn) {
                $(buttons[btn]).prop('disabled', true);
            });
            e.preventDefault();
            var options = {
                address_zip: document.getElementById('postal-code').value,
            };
            //stripe.createToken(cardNumberElement, options).then(setOutcome);
            stripe
                .createPaymentMethod({
                    type: 'card',
                    card: cardNumberElement
                })
                .then(setOutcome);

        });

    cardNumberElement.on('change', function (event) {
        var errorElement = document.querySelector('.error');
        errorElement.classList.remove('visible');
        if (event.error) {
            errorElement.textContent = event.error.message;
            errorElement.classList.add('visible');
        } else {
            errorElement.textContent = '';
        }
    });


    function setOutcome(result) {
        var errorElement = document.querySelector('.error');
        errorElement.classList.remove('visible');

        if (result.paymentMethod.id) {
            var form = document.getElementById('payment-form');
            var hiddenInput = document.createElement('input');
            hiddenInput.setAttribute('type', 'hidden');
            hiddenInput.setAttribute('name', 'paymentMethodId');
            hiddenInput.setAttribute('value', result.paymentMethod.id);
            form.appendChild(hiddenInput);
            form.submit();
        }
        else if (result.error) {
            errorElement.textContent = result.error.message;
            errorElement.classList.add('visible');
        }
    }
});