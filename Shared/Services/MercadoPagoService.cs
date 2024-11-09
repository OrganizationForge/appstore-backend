using Application.Common.Interfaces;
using Application.Common.Options;
using Application.Features.Payments.Commands.CreatePaymentCommand;
using MercadoPago.Client.Common;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.Extensions.Options;

namespace Shared.Services
{
    public class MercadoPagoService : IPaymentService
    {
        private readonly IOptions<MercadoPagoOptions> _mercadoPagoOptions;

        public MercadoPagoService(IOptions<MercadoPagoOptions> mercadoPagoOptions)
        {
            _mercadoPagoOptions = mercadoPagoOptions;
            MercadoPagoConfig.AccessToken = _mercadoPagoOptions.Value.AccessToken;
        }
        public async Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentCommand command)
        {
       
            var items = command.Products!.Select(product => new PreferenceItemRequest
            {
                Id = product.Id!.ToString(),
                Title = product.Title,
                CurrencyId = "ARS",  
                PictureUrl = product.PictureUrl,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Quantity = product.Quantity,
                UnitPrice = product.UnitPrice
            }).ToList();

            // Configura el payer (pagador)
            var Payer = new PreferencePayerRequest
            {
                Name = command.Customer!.Name,
                Surname = command.Customer.LastName,
                Email = command.Customer.Email,
                Phone = new PhoneRequest
                {
                    AreaCode = command.Customer.Phone.AreaCode,
                    Number = command.Customer.Phone.Number,
                },
                Identification = new IdentificationRequest
                {
                    Type = command.Customer.Identification.Type,
                    Number = command.Customer.Identification.Number,
                },
                Address = new AddressRequest
                {
                    StreetName = command.Customer.Address.Street,
                    StreetNumber = command.Customer.Address.Street,
                    ZipCode = command.Customer.Address.ZipCode
                }
            };

            // Crea la preferencia
            var preferenceRequest = new PreferenceRequest
            {
                Items = items,
                Payer = new PreferencePayerRequest(),
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = command.SuccessUrl,
                    Failure = command.FailureUrl,
                    Pending = command.PendingUrl
                },
                AutoReturn = "approved",
                NotificationUrl = command.NotificationUrl,
                StatementDescriptor = command.StatementDescriptor,
                ExternalReference = command.ExternalReference,
                Expires = command.Expires,
                ExpirationDateFrom = command.ExpirationDateFrom,
                ExpirationDateTo = command.ExpirationDateTo
            };

            // Aquí llama al cliente de Mercado Pago para crear la preferencia
            var client = new PreferenceClient();
            var preference = await client.CreateAsync(preferenceRequest);

            // Retorna la respuesta con la URL del Checkout y el ID del pago
            return new CreatePaymentResponse
            {
                CheckoutUrl = preference.InitPoint,
                PaymentId = preference.Id,
                PreferenceId = preference.Id,
                ExternalReference= preference.ExternalReference,
                ExpirationDate = preference.ExpirationDateTo

            };
        }
    }
}
