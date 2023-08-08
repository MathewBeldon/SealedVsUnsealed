import http from "k6/http";
import { check } from 'k6';
import { Counter, Trend } from 'k6/metrics';

const unsealedVirtualMediatorCounter = new Counter('Unsealed Virtual Mediator Counter');
const sealedVirtualMediatorCounter = new Counter('Sealed Virtual Mediator Counter');
const unsealedVirtualCounter = new Counter('Unsealed Virtual Counter');
const sealedVirtualCounter = new Counter('Sealed Virtual Counter');
const unsealedCounter = new Counter('Unsealed Counter');
const sealedCounter = new Counter('Sealed Counter');
const unsealedMediatorCounter = new Counter('Unsealed Mediator Counter');
const sealedMediatorCounter = new Counter('Sealed Mediator Counter');

const unsealedVirtualMediatorDuration= new Trend('Unsealed Virtual Mediator Duration');
const sealedVirtualMediatorDuration= new Trend('Sealed Virtual Mediator Duration');
const unsealedVirtualDuration= new Trend('Unsealed Virtual Duration');
const sealedVirtualDuration= new Trend('Sealed Virtual Duration');
const unsealedDuration= new Trend('Unsealed Duration');
const sealedDuration= new Trend('Sealed Duration');
const unsealedMediatorDuration= new Trend('Unsealed Mediator Duration');
const sealedMediatorDuration= new Trend('Sealed Mediator Duration');

const duration = 30;
const virtualUsers = 200;

export const options = {
    scenarios: {
        unsealedVirtualMediator: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'unsealedVirtualMediator'
        },
        sealedVirtualMediator: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'sealedVirtualMediator',
            startTime: `${duration + 1}s`
        },
        unsealedVirtual: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'unsealedVirtual',
            startTime: `${(duration + 1) * 2}s`
        },
        sealedVirtual: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'sealedVirtual',
            startTime: `${(duration + 1) * 3}s`
        },
        unsealed: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'unsealed',
            startTime: `${(duration + 1) * 4}s`
        },
        sealed: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'sealed',
            startTime: `${(duration + 1) * 5}s`
        },
        unsealedMediator: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'unsealedMediator',
            startTime: `${(duration + 1) * 6}s`
        },
        sealedMediator: {
            executor: "constant-vus",
            vus: virtualUsers,
            duration: `${duration}s`,
            gracefulStop: '0s',
            exec: 'sealedMediator',
            startTime: `${(duration + 1) * 7}s`
        },
    },
};

export function unsealedVirtualMediator() {
    const response = http.get('http://localhost:5000/test/unsealed/virtual/mediator');
    unsealedVirtualMediatorCounter.add(1);
    unsealedVirtualMediatorDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}

export function sealedVirtualMediator() {
    const response = http.get('http://localhost:5000/test/sealed/virtual/mediator');
    sealedVirtualMediatorCounter.add(1);
    sealedVirtualMediatorDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}

export function unsealedVirtual() {
    const response = http.get('http://localhost:5000/test/unsealed/virtual');
    unsealedVirtualCounter.add(1);
    unsealedVirtualDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}

export function sealedVirtual() {
    const response = http.get('http://localhost:5000/test/sealed/virtual');
    sealedVirtualCounter.add(1);
    sealedVirtualDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}

export function unsealed() {
    const response = http.get('http://localhost:5000/test/unsealed');
    unsealedCounter.add(1);
    unsealedDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}

export function sealed() {
    const response = http.get('http://localhost:5000/test/sealed');
    sealedCounter.add(1);
    sealedDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}

export function unsealedMediator() {
    const response = http.get('http://localhost:5000/test/unsealed/mediator');
    unsealedMediatorCounter.add(1);
    unsealedMediatorDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}

export function sealedMediator() {
    const response = http.get('http://localhost:5000/test/sealed/mediator');
    sealedMediatorCounter.add(1);
    sealedMediatorDuration.add(response.timings.duration);
    check(response, {
        "status code should be 200": res => res.status === 200,
    });
}