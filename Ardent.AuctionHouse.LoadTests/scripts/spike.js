import scenario from "./common.js";

export const options = {
    stages: [
        { duration: "30s", target: 10 },
        { duration: "10s", target: 500 },
        { duration: "2m", target: 500 },
        { duration: "30s", target: 10 },
        { duration: "1m", target: 0 }
    ]
};

export default scenario;