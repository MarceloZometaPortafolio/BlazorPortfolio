import React, { useEffect, useState } from 'react'
import { Card, CardContent, CardHeader } from '@material-ui/core';
import APIService from '../../Data/APIService'
import CategoryCard from './CategoryCard';

const Platforms = () => {              
    const [platforms, setPlatforms] = useState([]);        

    const getPlatforms = async() => {
        return await APIService.getPlatforms();        
    }

    useEffect(() => {       
        getPlatforms()
        .then(platsFound => {
            setPlatforms(platsFound);
        })                        
    }, []);

    return(
        <div>
            <Card>
                <CardHeader title={"Platforms"}/>
                <CardContent>                    
                    <CategoryCard category={platforms}/>               
                </CardContent>
            </Card>
        </div>
    );
}

export default Platforms