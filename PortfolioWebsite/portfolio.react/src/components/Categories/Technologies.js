import React, { useEffect, useState } from 'react'
import { Card, CardContent, CardHeader } from '@material-ui/core';
import APIService from '../../Data/APIService'
import CategoryCard from './CategoryCard';

const Technologies = () => {              
    const [technologies, setTechnologies] = useState([]);        

    const getTechnologies = async() => {
        return await APIService.getTechnologies();        
    }

    useEffect(() => {       
        getTechnologies()
        .then(techsFound => {
            setTechnologies(techsFound);
        })                        
    }, []);

    return(
        <div>
            <Card>
                <CardHeader title={"Technologies"}/>
                <CardContent>                    
                    <CategoryCard category={technologies}/>               
                </CardContent>
            </Card>
        </div>
    );
}

export default Technologies