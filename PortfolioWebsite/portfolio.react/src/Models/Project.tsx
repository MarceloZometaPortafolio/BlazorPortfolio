import axios from 'axios';

interface Project {
    id: number,
    title: string,
    requirement: string,
    design: string,
    completionDate: string
}

export default Project