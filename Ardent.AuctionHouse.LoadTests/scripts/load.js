import scenario from "./common.js";

export const options = {
    stages: [
        { duration: "2m", target: 50 },
        { duration: "10m", target: 50 },
        { duration: "2m", target: 0 }
    ]
};

export default scenario;