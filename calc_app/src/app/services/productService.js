import http from './httpService';
import { apiUrl } from '../../config.json';

export const getAverageCubicWeight = async () => {
    return await http.get(apiUrl + '/calculation');
}