import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';

const DetailProject = (props) => {
    const [slug, setSlug] = useState(props.match.params.slug);        

    return(
        <div>
            Hello from DetailProject, now showing {slug}
        </div>
    );
}

export default DetailProject