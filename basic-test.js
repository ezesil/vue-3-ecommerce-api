import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  insecureSkipTLSVerify: true,
  stages: [
        { duration: '1m', target: 1200 }
  ]
}

export default function() {
    http.get('https://localhost:49154/api/values');
    sleep(1);
}
