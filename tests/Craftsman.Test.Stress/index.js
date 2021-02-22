import http from 'k6/http';
const faker = require('faker-br');

const customerFake = () => ({
    name: faker.name.firstName(),
    fullName: faker.name.lastName(),
    cpf: faker.br.cpf(),
    email: faker.internet.email(),
    street: faker.address.streetName(),
    zipCode: faker.address.zipCode(),
    country: faker.address.country(),
    city: faker.address.city(),
    birthDate: faker.date.past()
});

console.log(customerFake())

export let options = {
    insecureSkipTLSVerify: true,
    vus: 2,
    iterations: 1000,
};

export default function () {

let res = http.post("https://localhost:5001/customer", JSON.stringify(customerFake()),
    { headers: { 'Content-Type': 'application/json' } });

console.log(res.json())

}