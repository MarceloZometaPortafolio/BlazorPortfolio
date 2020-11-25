import React, { useEffect, useState } from 'react'
import { Card, CardContent, CardHeader } from '@material-ui/core';
import APIService from '../../Data/APIService'
import CategoryCard from '../Projects/CategoryCard';

const Languages = (props) => {              
    const [languages, setLanguages] = useState([]);        

    const getLanguages = async() => {
        const languages = await APIService.getLanguages();

        return languages;
    }

    useEffect(() => {       
        getLanguages()
        .then(languagesFound => {
            setLanguages(languagesFound);
        })                        
    }, []);

    return(
        <div>
            <Card>
                <CardHeader title={"Languages"}/>
                <CardContent>                    
                    <CategoryCard category={languages}/>
          
       
                </CardContent>
            </Card>
        </div>
    );
}

export default Languages