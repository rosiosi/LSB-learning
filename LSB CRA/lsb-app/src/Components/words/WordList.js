import React from 'react';
import PropTypes from 'prop-types';
import WordCard from './WordCard';

const getWords = (words) => {
    return (
        <div className="card-deck">
            {
                words.map(word => <WordCard key={word.WordID} word={word} />)
            }
        </div>
    );
};

const WordList = (props) => (
    <div>
        {getWords(props.words)}
    </div>
);

WordList.defaultProps = {
    words: []
};

WordList.propTypes = {
    words: PropTypes.array
};

export default WordList;
