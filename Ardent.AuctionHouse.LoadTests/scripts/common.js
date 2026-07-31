import http from "k6/http";
import { check } from "k6";
import { randomGuid, randomValidEventId } from "../data/data.js";

const BASE_URL = __ENV.BASE_URL || "http://localhost:5000";

export function getAllEvents() {
    const response = http.get(`${BASE_URL}/api/events`);

    check(response, { "GET /events returned 200": r => r.status === 200 });
}

export function getValidEvent() {
    const id = randomValidEventId();

    const response = http.get(`${BASE_URL}/api/events/${id}`);

    check(response, { "GET existing event returned 200": r => r.status === 200 });
}

export function getInvalidEvent() {
    const response = http.get(
        `${BASE_URL}/api/events/${randomGuid()}`
    );

    check(response, { "GET invalid event returned 404": r => r.status === 404 });
}

export default function () {
    getAllEvents();
    getValidEvent();
    getInvalidEvent();
}