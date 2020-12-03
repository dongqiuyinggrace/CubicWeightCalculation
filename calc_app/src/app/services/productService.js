import http from './httpService'

export const getAveCubicWeight = async () => {
    return await http.get('http://localhost:5000/api/calculation');
}