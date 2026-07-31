import scenario from "./common.js";

export const options = {
    stages: [
        { duration: "2m", target: 50 },
        { duration: "2m", target: 100 },
        { duration: "2m", target: 200 },
        { duration: "2m", target: 400 },
        { duration: "2m", target: 0 }
    ]
};

export default scenario;